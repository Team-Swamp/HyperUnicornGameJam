using System.Collections;
using UnityEditor;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject npc;

    [Header("Player Settings")]
    [SerializeField] private float maxWalkSpeed;
    [SerializeField] private float normalWalkSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private int maxDistance;
    [SerializeField] private bool isWalking;
    [Space]
    public GameObject[] waypoints;
    
    private float noWalkSpeed;
    private int waypointIndex;

    private void Start() => waypointIndex = 0;

    private void Update()
    {
        StopAtPosition();
        WalkCheck();
        ChangeCourse();
    }

    private void ChangeCourse()
    {
        //if (Input.GetKeyDown(KeyCode.R)) waypointIndex--;
    }

    private void MoveToWaypoint()
    {
        normalWalkSpeed = maxWalkSpeed;
        
        if (Vector3.Distance(npc.transform.position, waypoints[waypointIndex].transform.position) < maxDistance) waypointIndex++;

        if (waypointIndex >= waypoints.Length) waypointIndex = 0;

        var lookAtWaypoint = Quaternion.LookRotation(waypoints[waypointIndex].transform.position - npc.transform.position);
        npc.transform.rotation = Quaternion.Slerp(transform.rotation, lookAtWaypoint, rotationSpeed * Time.deltaTime);
        
        npc.transform.Translate(0,0,normalWalkSpeed * Time.deltaTime);
    }

    private void StopAtPosition()
    {
        if (Input.GetKeyDown(KeyCode.T) && isWalking) NotAllowedToMove();

        else if (Input.GetKeyDown(KeyCode.T) && !isWalking) AllowedToMove();
    }

    private void WalkCheck()
    {
        if(isWalking) MoveToWaypoint();
        else NotAllowedToMove();
    }

    private void NotAllowedToMove()
    {
        isWalking = false;
        normalWalkSpeed = noWalkSpeed;
    }

    private void AllowedToMove()
    {
        isWalking = true;
        MoveToWaypoint();
    }

    private IEnumerator StandStill()
    {
        yield return new WaitForSeconds(1);
    }
}
