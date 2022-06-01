using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject bullet;
    float timer = 0;
    public float fireDelay;
    public GameObject firePos;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        if (fireDelay is 0)
            fireDelay = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > fireDelay)
        {
            GameObject temp = Instantiate(bullet, firePos.transform.position, firePos.transform.rotation);
            temp.transform.parent = player.transform;
            timer = 0f;
        }
    }
}
