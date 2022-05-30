using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance is null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);

        score = 1000;
        playerHealth = 200;
        fixedtime = Time.fixedDeltaTime;
        bgm = GameObject.Find("Player").GetComponent<AudioSource>();
        heli = GameObject.Find("Player").transform.Find("Helicopter").GetComponent<AudioSource>();
    }
    public static GameManager Instance
    {
        get
        {
            if (instance is null)
            {
                return null;
            }
            return instance;
        }
    }

    public int score;
    public int playerHealth;
    public const int Ammo = 150;
    public int damage = 5;
    public int plusDamage;

    float fixedtime;
    float musicSpeed = 1f;
    AudioSource bgm;
    AudioSource heli;
    public bool useEnchantedBullet = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            slowedTimer = 0f;

        if(!(bgm is null || heli is null))
            TimeSlow();

        if(useEnchantedBullet)
            PlusDamage();

        Debug.Log("plusDamage = " + plusDamage);
        Debug.Log(timer);
    }

    public float slowedTimer = 10f;

    public const float timeSlowAmmount = 10f;

    public void TimeStop()
    {
        score -= 250;
        slowedTimer = 0f;
    }
    void TimeSlow()
    {
        if(slowedTimer < 11)
            slowedTimer += Time.unscaledDeltaTime;

        if(slowedTimer < timeSlowAmmount)
        {
            Time.timeScale = 0.1f;
            Time.fixedDeltaTime = fixedtime * Time.deltaTime;

            musicSpeed = 0.7f;
            bgm.pitch = Mathf.Lerp(bgm.pitch, musicSpeed, bgm.pitch / musicSpeed * Time.deltaTime * 5f);
            heli.pitch = Mathf.Lerp(bgm.pitch, musicSpeed, bgm.pitch / musicSpeed * Time.deltaTime * 5f);
        }
        else
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = fixedtime;

            musicSpeed = 1.0f;
            if (bgm.pitch < 0.999f)
            {
                bgm.pitch = Mathf.Lerp(bgm.pitch, musicSpeed, bgm.pitch / musicSpeed * Time.deltaTime * 5f);
                heli.pitch = Mathf.Lerp(bgm.pitch, musicSpeed, bgm.pitch / musicSpeed * Time.deltaTime * 5f);
            }
            else
            {
                bgm.pitch = 1f;
                heli.pitch = 1f; 
            }
        }
    }

    float timer = 15f;
    void PlusDamage()
    {
        Debug.Log("강화중");
        if(useEnchantedBullet)
            timer += Time.unscaledDeltaTime;
        if (timer < 15f)
        {
            plusDamage = 5;
        }
        else
        {
            useEnchantedBullet = false;
            plusDamage = 0;
        }
    }

    public void EnchantedFire()
    {
        score -= 150;
        useEnchantedBullet = true;
        timer = 0f;
    }
}
