using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLook : MonoBehaviour
{
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("House Big");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(target);
        transform.LookAt(target.transform);
    }
}
