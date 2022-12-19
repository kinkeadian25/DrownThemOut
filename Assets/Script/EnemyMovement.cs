using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] Transform[] waypoints;

    int waypointIndex = 0;

    // Update is called once per frame
    void Update()
    {
        if (waypointIndex < waypoints.Length)
        {
            Vector3 difference = waypoints[waypointIndex].position - transform.position;
            transform.right = difference;
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

            if (difference.magnitude < 0.1f)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
