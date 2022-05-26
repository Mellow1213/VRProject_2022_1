using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject enemyPosition;
    Transform[] enemyPositions;

    Transform targetObject;
    Transform playerPos;

    [SerializeField]  private float speed = 1f;
    [SerializeField]  private float length = 1f;
    private float runningTime = 0f;
    private float yPos = 0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyPosition = GameObject.Find("EnemyPosition");
        playerPos = GameObject.Find("PlayerPos").GetComponent<Transform>();
        enemyPositions = enemyPosition.GetComponentsInChildren<Transform>();
        targetObject = enemyPositions[Random.Range(0,enemyPositions.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        //sin함수 값으로 Flyer가 계속 위아래로 공중부양하듯이 연출
        runningTime += Time.deltaTime * speed;
        yPos = Mathf.Sin(runningTime) * length * 0.07f;
        this.transform.localPosition = new Vector3(transform.position.x, transform.position.y + yPos, transform.position.z);


        transform.LookAt(playerPos);
        transform.position = Vector3.Lerp(gameObject.transform.position, targetObject.position, 2.0f*Time.deltaTime);
    }
}
