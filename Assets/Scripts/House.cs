using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>( out Thief thief))
        {
            _alarm.IncreaseVolume();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Thief>(out Thief thief))
        {
            _alarm.DecreaseVolume();
        }
    }
}