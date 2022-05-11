using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterMove : MonoBehaviour
{
    public float speed = 9.0f;
    public float damping = 3.0f;
    private Transform playerTransform;
    private Transform[] waypoints;
    private int nextIndex = 1;

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
        if (Input.GetKeyDown(KeyCode.A)) // 테스트용 -  헬리콥터 이동 정지 토글 버튼
            go = !go;

        if(go)
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
        if (other.CompareTag("Finalpoint"))
            go = false;

        if (other.CompareTag("Waypoint"))
            nextIndex = (++nextIndex >= waypoints.Length) ? 1 : nextIndex;
    }
}
