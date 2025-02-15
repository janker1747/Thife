using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private float _targetVolume;
    public float _volumeStep = 0.1f;

    void Start()
    {
        _audioSource.volume = 0.0f;
        _targetVolume = 0.0f;
        _audioSource.Play();
    }

    void Update()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _volumeStep * Time.deltaTime);
    }

    public void IncreaseVolume()
    {
        _targetVolume = 1.0f;
    }

    public void DecreaseVolume()
    {
        _targetVolume = 0.0f;
    }
}
