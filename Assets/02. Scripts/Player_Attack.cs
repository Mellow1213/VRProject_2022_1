using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public GameObject bullet_Prefab;
    public GameObject fire_Pos;
    public AudioClip fireSound;

    AudioSource audioSource;

    public float fireRate; // 발사 속도, 발사와 발사 사이 간격
    public int ammo; // 탄창 수

    Transform firepos;

    bool isAmmoEmpty = false;
    bool isReloading = false;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ammo = 50;
        firepos = fire_Pos.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        fireRate -= Time.deltaTime;
        if(ammo < 0 && !isReloading)
        {
            isAmmoEmpty = true;
        }

        if (!isAmmoEmpty)
        {
            if (Input.GetMouseButton(0) && fireRate < 0)
            {
                Fire();
            }
        }
        else if (isAmmoEmpty)
        {
                StartCoroutine(Reload());
        }

    }
    void Fire()
    {
        Instantiate(bullet_Prefab, firepos.transform.position, firepos.transform.rotation);
        ammo--;
        fireRate = 0.08f;
        audioSource.PlayOneShot(fireSound);
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(1.0f);
        ammo = 50;
        isAmmoEmpty = false;
        isReloading = false;
    }
}
