﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemySpawn : MonoBehaviour
{
    public GameObject flyerEnemy;
    float timer = -10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //Debug.Log("FlyerSpawn (D)");
        if (Input.GetKeyDown(KeyCode.D) || timer > 10f)
        {
            Instantiate(flyerEnemy);
            timer = 0f;
        }

    }
}