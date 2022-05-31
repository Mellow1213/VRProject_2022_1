using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLook : MonoBehaviour
{
    private GameObject target;
    private Vector3 lookPosition;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Shelter");
        lookPosition = new Vector3(target.transform.position.x, target.transform.position.y + 80, target.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(lookPosition);
    }
}
