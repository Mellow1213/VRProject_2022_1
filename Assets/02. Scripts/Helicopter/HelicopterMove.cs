using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterMove : MonoBehaviour
{
    public float speed = 1.0f;
    public float damping = 3.0f;
    private Transform playerTransform;
    private Transform[] waypoints;
    private int nextIndex = 1;
    int loopIndex;

    public bool loopEndSwitch = false;
    bool goSwitch = true;


    void Start()
    {
        playerTransform = GetComponent<Transform>();
        waypoints = GameObject.Find("WaypointGroup").GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("loopEndSwitch (A) = " + loopEndSwitch);
        //Debug.Log("goSwitch (S) = " + goSwitch);
        if (Input.GetKeyDown(KeyCode.A)) // 디버그 - 루프 On/Off
            loopEndSwitch = !loopEndSwitch;
        if (Input.GetKeyDown(KeyCode.S)) // 디버그 - 이동 On/Off
            goSwitch = !goSwitch;


        if (goSwitch)
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
            if (loopEndSwitch)
                nextIndex++;
            else
                nextIndex = loopIndex;
        }

        if (other.CompareTag("Finalpoint"))
        {
            nextIndex++;
            speed = Mathf.Lerp(speed, 0f, 0.8f);
            GameManager.Instance.Clear();
        }

        if (other.CompareTag("Waypoint"))
            nextIndex++;

        if (other.CompareTag("MapCtrlpoint"))
        {
            nextIndex++;
            other.GetComponent<CreateMap>().MapCtrl();
        }

    }
}
