
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveCtrl : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 20);

        for(int i=0; i<colliders.Length; i++)
        {
            Rigidbody enemy = colliders[i].GetComponent<Rigidbody>();
            enemy.AddExplosionForce
        }
    }
}
