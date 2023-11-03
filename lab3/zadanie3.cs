using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie3 : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector3[] waypoints = new Vector3[4];
    private int currentWaypoint = 0;

    void Start()
    {
        waypoints[0] = transform.position + Vector3.right * 10.0f;
        waypoints[1] = waypoints[0] + Vector3.forward * 10.0f;
        waypoints[2] = waypoints[1] - Vector3.right * 10.0f;
        waypoints[3] = transform.position;
        transform.position = waypoints[0];
    }

    void Update()
    {
        Vector3 direction = waypoints[currentWaypoint] - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint]) < 0.1f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            transform.Rotate(Vector3.up, 90.0f);
        }
    }
}
