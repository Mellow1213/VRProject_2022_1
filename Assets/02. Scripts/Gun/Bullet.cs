using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bullet_Speed;
    public int bulletDamage;
    public GameObject fireEffect;
    // Start is called before the first frame update
    void Start()
    {
        bulletDamage = 5;
        bullet_Speed = 800f;
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * bullet_Speed * Time.deltaTime ;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(fireEffect.gameObject, transform.position, transform.rotation);
        Debug.Log("맞은 개체 이름 : " + collision.gameObject.name);

        if(!(collision.gameObject.GetComponent<Status>() is null)){
            Status status = collision.gameObject.GetComponent<Status>();
            status.Damaged(bulletDamage);
        }
        Destroy(gameObject);
    }
}
