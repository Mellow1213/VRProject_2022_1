using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public GameObject bullet_Prefab;
    public GameObject fire_Pos;

    public GameObject bullet_Shell_Prefab;
    public GameObject bullet_Shell_Pos;

    public GameObject fire_Effect;
    public GameObject muzzle_Pos;

    public GameObject minigun_head;
    public AudioClip fireSound;


    AudioSource audioSource;

    public float fireRate; // 발사 속도, 발사와 발사 사이 간격
    public int ammo; // 탄창 수

    GameObject tempObject;

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

        if (Input.GetMouseButton(0) && !isAmmoEmpty)
        {
            GunRotate();

            if (fireRate < 0)
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
        tempObject = Instantiate(bullet_Shell_Prefab, bullet_Shell_Pos.transform.position, bullet_Shell_Pos.transform.rotation);
        tempObject.transform.parent = this.transform;
        tempObject = Instantiate(fire_Effect, muzzle_Pos.transform.position, muzzle_Pos.transform.rotation);
        tempObject.transform.parent = this.transform;

        ammo--;
        fireRate = 0.08f;
        audioSource.PlayOneShot(fireSound);
    }

    void GunRotate()
    {
        minigun_head.transform.Rotate(Vector3.up * 25f);
    }

    IEnumerator Reload()
    {
        isReloading = true;
        ammo = 50;
        yield return new WaitForSeconds(1.0f);
        isAmmoEmpty = false;
        isReloading = false;
    }
}
