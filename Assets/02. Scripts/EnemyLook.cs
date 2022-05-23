using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLook : MonoBehaviour
{
    public Transform target;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(targetPosition);

        transform.rotation = rotation;
    }
}
