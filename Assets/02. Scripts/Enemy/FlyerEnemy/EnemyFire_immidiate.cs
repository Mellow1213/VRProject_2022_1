using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire_immidiate : MonoBehaviour
{
    public GameObject fireEffect;
    public float fireRate;
    public GameObject firePos;
    public float fireDamage;
    public AudioClip fireSound;

    GameObject player;

    AudioSource audiosource;
    float timer = 0f;
    CountLeftEnemy cl;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        audiosource = player.GetComponent<AudioSource>();
        cl = player.GetComponent<CountLeftEnemy>();   
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > fireRate)
        {
            StartCoroutine(Fire());
            timer = 0f;
        }
    }

    IEnumerator Fire()
    {
        GameObject temp = Instantiate(fireEffect, firePos.transform.position, firePos.transform.rotation);
        temp.transform.parent = firePos.transform;
            temp.transform.localPosition = Vector3.zero;
            temp.transform.localScale = new Vector3(10f, 10f, 10f);
        Destroy(temp, 0.5f);
        //사운드 재생
        audiosource.PlayOneShot(fireSound);
        cl.playerHP -= fireDamage;
        //플레이어 피 깎기
        yield return null;
    }
}
