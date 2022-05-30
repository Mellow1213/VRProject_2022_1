﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterStatus : MonoBehaviour
{
    public GameObject explosion;
    private Transform shelter;
    private float HP;
    public static bool isBoom;
    private float damage;
    // Start is called before the first frame update
    void Start()
    {
        shelter = this.transform.parent;
        HP = 50.0f;
        damage = 0.5f;
        isBoom = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            HP -= damage;
        if (HP <= 0)
            Explosion();
    }

    void Explosion()
    {
        this.gameObject.SetActive(false);
        explosion.SetActive(true);
        Destroy(shelter.gameObject, 3.0f);
        isBoom = true;
    }
}
