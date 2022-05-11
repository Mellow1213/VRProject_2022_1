using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointTrack : MonoBehaviour
{
    Color lineColor = Color.black;
    private Transform[] waypoints;

    private void OnDrawGizmos()
    {

        Gizmos.color = lineColor;
        waypoints = GetComponentsInChildren<Transform>();

        int nextIndex = 1;
        Vector3 currentPosition = waypoints[nextIndex].position;
        Vector3 nextPosition;

        for (int i = 1; i < waypoints.Length-1; i++)
        {
            nextPosition = waypoints[++nextIndex].position;
            Gizmos.DrawLine(currentPosition, nextPosition);

            currentPosition = nextPosition;
        }
    }
}
