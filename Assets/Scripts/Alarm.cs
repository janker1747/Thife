using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeStep = 0.1f;

    private float _targetVolume = 0f;
    private Coroutine _volumeChangeCoroutine;

    private void Awake()
    {
        _audioSource.volume = 0f;
        _audioSource.Play();
    }

    public void IncreaseVolume()
    {
        _targetVolume = 1f;
        StartVolumeChange();
    }

    public void DecreaseVolume()
    {
        _targetVolume = 0f;
        StartVolumeChange();
    }

    private void StartVolumeChange()
    {
        if (_volumeChangeCoroutine != null)
        {
            StopCoroutine(_volumeChangeCoroutine);
        }

        _volumeChangeCoroutine = StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (!Mathf.Approximately(_audioSource.volume, _targetVolume))
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _volumeStep * Time.deltaTime);

            yield return null; 
        }

        _volumeChangeCoroutine = null;
    }
}