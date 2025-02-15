using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _speed = 4f;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Transform _escapePosition;
    [SerializeField] private float _minDistance = 1f;
    private float _maxVolume = 1f;
    private int _currentWaypointIndex = 0;
    private bool _isEscaping = false;
    private bool _isSignalingTriggered = false;

    private void Update()
    {
        if (_waypoints == null || _waypoints.Length == 0 || _escapePosition == null)
            return;

        if (_isSignalingTriggered && Mathf.Approximately(_audioSource.volume, _maxVolume))
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
        if (_isEscaping) return;

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypointIndex].position, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _waypoints[_currentWaypointIndex].position) < _minDistance)
        {
            _currentWaypointIndex = ++_currentWaypointIndex % _waypoints.Length;
        }
    }

    private void Escape()
    {
        transform.position = Vector3.MoveTowards(transform.position, _escapePosition.position, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _escapePosition.position) < _minDistance)
        {
            _isEscaping = false; 
            _isSignalingTriggered = false;
        }
    }

    public void SetSignalingTriggered(bool isTriggered)
    {
        _isSignalingTriggered = isTriggered;
    }
}
