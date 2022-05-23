﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunCtrl : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSpawn;

    private bool isFire;

    // Start is called before the first frame update
    void Start()
    {
        isFire = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFire)
        {
            StartCoroutine(Fire());
            isFire = true;
        }
            
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(3.0f);
        Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);

        isFire = false;    
    }
}