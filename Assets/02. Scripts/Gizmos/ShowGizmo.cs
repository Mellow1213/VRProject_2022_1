using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGizmo : MonoBehaviour
{
    Color pointColor = Color.green;
    float radius = 1.5f;




    private void OnDrawGizmos()
    {
        Gizmos.color = pointColor;
        Gizmos.DrawSphere(transform.position, radius);
    }
}