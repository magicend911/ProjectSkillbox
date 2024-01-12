using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    [SerializeField] private Vector3[] waypoints; 
    [SerializeField] private float moveSpeed = 5f; 

    private bool forward = true;
    private int currentWaypoint = 0;

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (waypoints.Length == 0)
            return;

        if (forward)
        {
            var distance = Vector3.Distance(transform.position, waypoints[currentWaypoint]);

            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint], moveSpeed * Time.deltaTime);

            if (distance < 0.1f)
            {
                currentWaypoint++;

                if (currentWaypoint == waypoints.Length)
                {
                    forward = false;
                    currentWaypoint = waypoints.Length - 1;
                }
            }
        }
        else
        {
            var distance = Vector3.Distance(transform.position, waypoints[currentWaypoint]);

            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint], moveSpeed * Time.deltaTime);

            if (distance < 0.1f)
            {
                currentWaypoint--;

                if (currentWaypoint < 0)
                {
                    forward = true;
                    currentWaypoint = 0;
                }
            }
        }
    }
}
