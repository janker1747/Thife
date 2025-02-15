using System;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;
    public event Action<bool> OnAlarm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Thief>())
        {
            _alarm.IncreaseVolume();
            OnAlarm?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Thief>())
        {
            _alarm.DecreaseVolume();
            OnAlarm?.Invoke(false);
        }
    }
}