using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bullet_Speed;
    // Start is called before the first frame update
    void Start()
    {
        bullet_Speed = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * bullet_Speed * Time.deltaTime ;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
