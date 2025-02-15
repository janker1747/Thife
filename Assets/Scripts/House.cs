using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Alarm alarm;
    [SerializeField] private Thief _thife;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Thief>())
        {
            alarm.IncreaseVolume();
            _thife.SetSignalingTriggered(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Thief>())
        {
            alarm.DecreaseVolume();
            _thife.SetSignalingTriggered(false);
        }
    }
}
