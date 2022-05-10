using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bullet_Speed;
    public int bulletDamage;
    // Start is called before the first frame update
    void Start()
    {
        bulletDamage = 10;
        bullet_Speed = 2500f;
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * bullet_Speed * Time.deltaTime ;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("맞은 개체 이름 : " + collision.gameObject.name);
        Destroy(gameObject);

        Status status = collision.gameObject.GetComponent<Status>();
        status.Damaged(bulletDamage);
    }
}
