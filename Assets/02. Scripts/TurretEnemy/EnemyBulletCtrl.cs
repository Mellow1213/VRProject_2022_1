using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCtrl : MonoBehaviour
{
    public float bulletSpeed = 20.0f;
    public GameObject fireEffect;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.transform.forward * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Shelter"))
        {
            Instantiate(fireEffect, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
