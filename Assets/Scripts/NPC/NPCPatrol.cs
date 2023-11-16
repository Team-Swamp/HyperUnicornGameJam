using UnityEngine;

public class NPCPatrol : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float waitTime;
    [SerializeField] private float longerWaitTime;
    [SerializeField] private float specificWaitPoint;
    [SerializeField] private Transform[] waypoints;

    private int _currentWaypointIndex;
    private float _waitCounter;
    private bool _waiting;

    private void Update() => Move();

    private void Move()
    {
        if(!WaitToMove()) return;
        
        var waypoint = waypoints[_currentWaypointIndex];
        if (Vector3.Distance(transform.position, waypoint.position) < 0.01f)
        {
            transform.position = waypoint.position;
            _waitCounter = 0f;
            _waiting = true;

            _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
        }
        else
        {
            var position = transform.position;
            var lookAtWaypoint = Quaternion.LookRotation(waypoints[_currentWaypointIndex].transform.position - position);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookAtWaypoint, rotationSpeed * Time.deltaTime);
            
            position = Vector3.MoveTowards(position, waypoint.position, speed * Time.deltaTime);
            transform.position = position;
        }
    }

    private bool WaitToMove()
    {
        if (_waiting)
        {
            _waitCounter += Time.deltaTime;
            if (_currentWaypointIndex == specificWaitPoint && _waitCounter < longerWaitTime) return false;
            if(_waitCounter < waitTime) return false; 
            _waiting = true;
        }
        return true;
    }
}
