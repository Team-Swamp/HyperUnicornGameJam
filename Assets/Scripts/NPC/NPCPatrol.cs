using UnityEngine;

public class NPCPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float waitTime;

    private int _currentWaypointIndex;
    private float _waitCounter;
    [SerializeField] private bool _waiting;

    private void Update() => MoveNPC();

    private void MoveNPC()
    {
        WaitToMove();
        
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

    private void WaitToMove()
    {
        if (_waiting)
        {
            _waitCounter += Time.deltaTime;
            if(_waitCounter < waitTime) return;
            _waiting = false;
        }
    }
}
