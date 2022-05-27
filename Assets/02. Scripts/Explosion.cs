using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject.GetComponent<Status>() is null))
        {
            Status status = collision.gameObject.GetComponent<Status>();
            status.Damaged(100);
        }
        transform.GetComponent<Collider>().isTrigger = true;
    }
}
