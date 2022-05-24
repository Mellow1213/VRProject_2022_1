﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterMove : MonoBehaviour
{
    public bool doLoop = false; // 계속 돌지 안돌지, 테스트용
    public float speed = 9.0f;
    public float damping = 3.0f;
    private Transform playerTransform;
    private Transform[] waypoints;
    private int nextIndex = 1;

    int loopIndex;

    bool go = true;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        waypoints = GameObject.Find("WaypointGroup").GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("go = " + go);
        Debug.Log("nextIndex = " + nextIndex);
        if (Input.GetKeyDown(KeyCode.A)) // 테스트용 - 루프 On/Off
            go = !go;

        MoveWayPoint();
    }

    void MoveWayPoint()
    {
        Vector3 direction = waypoints[nextIndex].position - playerTransform.position;
        Quaternion goalRotation = Quaternion.LookRotation(direction);

        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, goalRotation,
            Time.deltaTime * damping);
        playerTransform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Looppoint"))
        {
            loopIndex = nextIndex++;
        }

        if (other.CompareTag("LoopEndpoint"))
        {
            if (go)
                nextIndex++;
            else
                nextIndex = loopIndex;
        }

        if (other.CompareTag("Finalpoint"))
        {
            nextIndex++;
            speed = Mathf.Lerp(speed, 0f, 0.8f);
        }

        if (other.CompareTag("Waypoint"))
            nextIndex++;
    }
}
