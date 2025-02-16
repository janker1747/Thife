using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _minDistance = 0.1f;

    private int _currentWaypointIndex = 0;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            _waypoints[_currentWaypointIndex].position,
            _speed * Time.deltaTime
        );

        if ((transform.position - _waypoints[_currentWaypointIndex].position).sqrMagnitude < _minDistance * _minDistance)
        {
            _currentWaypointIndex = ++_currentWaypointIndex % _waypoints.Length;
        }
    }
}