using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject[] enemyPosition;

    float timeRate;
    Transform playerPos;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.Find("PlayerPos").transform;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerPos);

        timeRate += Time.deltaTime;

        if (timeRate > 5f)
        {
            i = Random.Range(0, enemyPosition.Length);
            timeRate = 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, enemyPosition[i].transform.position, Time.deltaTime);
    }

    


}
