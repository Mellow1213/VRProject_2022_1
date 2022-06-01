using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Attack : MonoBehaviour
{
    public GameObject bullet_Prefab;
    public GameObject enchantedBulletPrefab;
    public GameObject fire_Pos;

    public GameObject bullet_Shell_Prefab;
    public GameObject bullet_Shell_Pos;

    public GameObject normalFireEffect;
    public GameObject enchantedFireEffect;
    GameObject fire_Effect;
    public GameObject muzzle_Pos;

    public GameObject minigun_head;
    public AudioClip normalFireSound;
    public AudioClip enchantedFireSound;
    AudioClip fireSound;

    PlayerGunRotateFix playerGunRotateFix;
    public GameObject playerGunRotateFixObject;

    AudioSource audioSource;
    public AudioClip WinDown;

    public Image ammoImage;
    public TextMeshProUGUI leftAmmoText;
    public TextMeshProUGUI scoreText;

    private float fireRate; // 발사 속도, 발사와 발사 사이 간격
    private int ammo; // 탄창 수

    float waitingTime = 0;

    float gunRotateSpeed;

    GameObject tempObject;

    Transform firepos;

    bool isAmmoEmpty = false;
    bool isReloading = false;
    bool isGunSpinned = false;

    void Start()
    {
        playerGunRotateFix = playerGunRotateFixObject.GetComponent<PlayerGunRotateFix>();
        audioSource = GetComponent<AudioSource>();
        ammo = GameManager.Ammo;
        firepos = fire_Pos.GetComponent<Transform>();
        gunRotateSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 총 발사 간격 계산
        if (fireRate >= -1f)
            fireRate -= Time.unscaledDeltaTime;

        // 탄창이 비었는지 확인
        if (ammo < 0 && !isReloading)
        {
            ammo = 0;
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
                waitingTime = 0f;
                Fire();
            }
        }
        else
        {
            //총알이 바닥났거나 꽉 차있는 상태가 아니라면, 그리고 재장전 중이 아니라면 대기시간 측정
            if ((isAmmoEmpty || ammo != GameManager.Ammo) && !isReloading)
                waitingTime += Time.unscaledDeltaTime;

            // 탄창이 비어있거나 총을 발사하지 않은지 3초가 지나면
            if (isAmmoEmpty || waitingTime > 3f)
            {
                waitingTime = 0f;
                StartCoroutine(Reload());
            }
        }
    }
    void Fire()
    {
        ammo--;
        if (GameManager.Instance.useEnchantedBullet)
        {
            Instantiate(enchantedBulletPrefab, firepos.transform.position, firepos.transform.rotation);
            fireSound = enchantedFireSound;
            fire_Effect = enchantedFireEffect;
            audioSource.volume = 1f;
        }
        else
        {
            fireSound = normalFireSound;
            fire_Effect = normalFireEffect;
            Instantiate(bullet_Prefab, firepos.transform.position, firepos.transform.rotation);
            audioSource.volume = 0.3f;
        }

        tempObject = Instantiate(bullet_Shell_Prefab, bullet_Shell_Pos.transform.position, bullet_Shell_Pos.transform.rotation);
        tempObject.transform.parent = this.transform;
        tempObject = Instantiate(fire_Effect, muzzle_Pos.transform.position, muzzle_Pos.transform.rotation);
        tempObject.transform.parent = muzzle_Pos.transform;
        fireRate = 0.08f;
        audioSource.PlayOneShot(fireSound);
    }

    void GunRotate()
    {
        // 마우스를 누르고 있고, 총알이 비어있지 않으며, 총열이 일정 수준 이상 빠르게 돌지 않음.
        if (Input.GetMouseButton(0) && !isAmmoEmpty && playerGunRotateFix.getPermissionToFire())
        {
            isGunSpinned = true;
            if (gunRotateSpeed <= 15f)
            {
                gunRotateSpeed += Time.unscaledDeltaTime * 20f;
            }
        }
        else
        {
            if (isGunSpinned && ( gunRotateSpeed >= 10f && Input.GetMouseButtonUp(0)) )
            {
                audioSource.PlayOneShot(WinDown);
                isGunSpinned = false;
            }
            // 마우스를 뗐을 때. 총의 속도는 0 이하로 내려가지 않음.
            if (gunRotateSpeed > 0)
            {
                gunRotateSpeed -= Time.unscaledDeltaTime * 10;
            }
        }

        if (gunRotateSpeed <= 0.05f) // 회전이 멈췄을 때 gunRotateSpeed값이 음수라면 0으로 보정
            gunRotateSpeed = 0f;

        minigun_head.transform.Rotate(Vector3.up * gunRotateSpeed);
    }


    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSecondsRealtime(1.5f);
        ammo = GameManager.Ammo;
        isAmmoEmpty = false;
        isReloading = false;
    }
    public void DeleteChilds(GameObject target)
    {
        Transform[] child = target.GetComponentsInChildren<Transform>();

        foreach (var iter in child)
        {
            // 부모(target)는 삭제 하지 않음
            if (iter != target.transform)
            {
                Destroy(iter.gameObject);
            }
        }
    }

    void AmmoUI()
    {
        float leftAmmo = ammo / (float)GameManager.Ammo;
        if (isReloading)
            leftAmmoText.text = "Reloading...";
        else
            leftAmmoText.text = "Left Ammo : " + ammo;
        ammoImage.fillAmount = leftAmmo;
    }

    private void FixedUpdate()
    {
        scoreText.text = "Current Score\n" + GameManager.Instance.score;
        AmmoUI();
    }
}
