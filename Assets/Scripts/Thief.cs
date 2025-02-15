using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Transform _escapePoint;
    [SerializeField] private float _minDistance = 1f;
    [SerializeField] private House _house;

    private int _currentWaypointIndex = 0;
    private bool _isSignalingTriggered = false;

    private void OnEnable()
    {
        _house.OnAlarm += HandleAlarmStateChanged;
    }

    private void OnDisable()
    {
        _house.OnAlarm -= HandleAlarmStateChanged;
    }

    private void Update()
    {
        if (_waypoints == null || _waypoints.Length == 0)
            return;

        if (_isSignalingTriggered == true)
        {
            Escape();
        }
        else
        {
            Move();   
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            _waypoints[_currentWaypointIndex].position,
            _speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, _waypoints[_currentWaypointIndex].position) < _minDistance)
        {
            _currentWaypointIndex = ++_currentWaypointIndex % _waypoints.Length;
        }
    }

    private void Escape()
    {
        Debug.Log("Thief is escaping!");
        transform.position = Vector3.MoveTowards(
            transform.position,
            _escapePoint.position,
            _speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, _escapePoint.position) < _minDistance)
        {
            Debug.Log("Вор сбежал!");
            Destroy(gameObject);
        }
    }

    private void HandleAlarmStateChanged(bool isAlarmTriggered)
    {
        _isSignalingTriggered = isAlarmTriggered;
        Debug.Log($"Thief detected alarm state change: {isAlarmTriggered}");
    }
}