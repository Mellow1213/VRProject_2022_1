using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMove : MonoBehaviour
{
    public float speed;
    public GameObject hitEffect;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.right* speed*Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject b = Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(b, 2.0f);
        if (!(collision.gameObject.GetComponent<Status>() is null))
        {
            Status status = collision.gameObject.GetComponent<Status>();
            status.Damaged(200);
        }
    }
}
