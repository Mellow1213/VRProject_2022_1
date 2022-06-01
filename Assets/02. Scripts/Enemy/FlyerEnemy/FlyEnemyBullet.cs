using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyBullet : MonoBehaviour
{
    GameObject hitPoint;
    float speed = 0;
    CountLeftEnemy player;
    public GameObject FireEffect;
    public float fireDamage;

    public AudioClip fireSound;
    // Start is called before the first frame update
    void Start()
    {
        hitPoint = GameObject.Find("HitPoint");
        player = GameObject.Find("Player").GetComponent<CountLeftEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, hitPoint.transform.position, Mathf.Lerp(speed, 6f, 10*Time.deltaTime));

        transform.LookAt(hitPoint.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.Equals(hitPoint))
        {
            Debug.Log("확인");
            Instantiate(FireEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            player.GetComponent<AudioSource>().PlayOneShot(fireSound);
            player.playerHP -= fireDamage;
        }
    }
}
