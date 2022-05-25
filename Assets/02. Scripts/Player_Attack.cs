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

    PlayerGunRotateFix playerGunRotateFix;
    public GameObject playerGunRotateFixObject;

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
        playerGunRotateFix = playerGunRotateFixObject.GetComponent<PlayerGunRotateFix>();
        audioSource = GetComponent<AudioSource>();
        ammo = 50;
        firepos = fire_Pos.GetComponent<Transform>();
        gunRotateSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {


        // 총 발사 간격 계산
        if (fireRate >= -1f)
            fireRate -= Time.deltaTime;
        
        // 탄창이 비었는지 확인
        if (ammo < 0 && !isReloading)
        {
            isAmmoEmpty = true;
        }

        // 미니건 총열 회전
        GunRotate();

        // 마우스 클릭시, 탄창이 비어있지 않을 때
        if (Input.GetMouseButton(0) && !isAmmoEmpty)
        {
            // 발사 딜레이가 지났고 총이 예열 되었다면 -> 예열되지 않았다면 총알 발사 X
            if (fireRate < 0 && gunRotateSpeed >= 10f)
            {
                Fire();
            }
        }
        // 탄창이 비어있다면
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
        tempObject.transform.parent = muzzle_Pos.transform;

        ammo--;
        fireRate = 0.08f;
        audioSource.PlayOneShot(fireSound);
    }

    void GunRotate()
    {
        // 마우스를 누르고 있고, 총알이 비어있지 않으며, 총이 발사 가능 화면 안에 있을 때 총열 회전.  + 총열이 일정 수준 이상 빠르게 돌지 않음.
        if (Input.GetMouseButton(0) && !isAmmoEmpty && playerGunRotateFix.getPermissionToFire() && gunRotateSpeed <= 15f) 
            gunRotateSpeed += Time.deltaTime * 8;
        else if (gunRotateSpeed > 0) // 총의 속도는 0 이하로 내려가지 않음.
            gunRotateSpeed -= Time.deltaTime * 20;

        if (gunRotateSpeed <= 0) // 회전이 멈췄을 때 gunRotateSpeed값이 음수라면 0으로 보정
            gunRotateSpeed = 0f;

        minigun_head.transform.Rotate(Vector3.up * gunRotateSpeed);
    }

    IEnumerator Reload()
    {
        isReloading = true;
        ammo = 100;
        yield return new WaitForSeconds(1.0f);
        isAmmoEmpty = false;
        isReloading = false;
    }
}
