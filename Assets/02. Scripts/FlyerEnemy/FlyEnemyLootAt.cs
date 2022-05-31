using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyLootAt : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.Find("PlayerPos");
    }

    void Update()
    {
        // 계속 플레이어 쳐다보기
        transform.LookAt(player.transform);


    }
}
