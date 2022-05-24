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

    float gunRotateSpeed;

    GameObject tempObject;

    Transform firepos;

    bool isAmmoEmpty = false;
    bool isReloading = false;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ammo = 50;
        firepos = fire_Pos.GetComponent<Transform>();
        gunRotateSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(fireRate >= -1f )
            fireRate -= Time.deltaTime;
        if(ammo < 0 && !isReloading)
        {
            isAmmoEmpty = true;
        }

        GunRotate();

        if (Input.GetMouseButton(0) && !isAmmoEmpty)
        {

            if (fireRate < 0 && gunRotateSpeed >= 10f)
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
        if (Input.GetMouseButton(0) && gunRotateSpeed <= 15f && !isAmmoEmpty)
            gunRotateSpeed += Time.deltaTime * 8;
        else if (gunRotateSpeed >= 0)
            gunRotateSpeed -= Time.deltaTime * 20;

        if (gunRotateSpeed <= 0)
            gunRotateSpeed = 0f;

        minigun_head.transform.Rotate(Vector3.up * gunRotateSpeed);
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
