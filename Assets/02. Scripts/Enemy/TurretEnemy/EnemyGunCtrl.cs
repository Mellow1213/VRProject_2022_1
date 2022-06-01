using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunCtrl : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSpawn;
    public AudioClip fireSound;
    private GameObject Turrets;
    public bool isFire;

    // Start is called before the first frame update
    void Start()
    {
        Turrets = GameObject.Find("EnemyTurrets");
        isFire = false;
    
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isFire)
        {
            StartCoroutine(Fire());
            isFire = true;
        }
            
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(10.0f);
        Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        Turrets.GetComponent<AudioSource>().PlayOneShot(fireSound);

        isFire = false;    
    }
}
