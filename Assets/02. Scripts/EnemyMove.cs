using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject[] enemyPosition;

    Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.Find("PlayerPos").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerPos);

    }

    


}
