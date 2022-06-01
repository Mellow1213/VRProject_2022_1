using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterStatus : MonoBehaviour
{
    public GameObject explosion;
    public AudioClip explosionSound;
    private Transform shelter;
    public float HP;
    public static bool isExplosion;
    private float damage;

    // Start is called before the first frame update
    void Start()
    {
        shelter = this.transform.parent;
        damage = 1.0f;
        isExplosion = false;
    }

    public float getShelterHP()
    {
        return HP;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            HP -= damage;
        if (HP <= 0)
            Explosion();
    }

    void Explosion()
    {
        shelter.gameObject.GetComponent<AudioSource>().PlayOneShot(explosionSound);
        this.gameObject.SetActive(false);
        explosion.SetActive(true);
        Destroy(shelter.gameObject, 3.0f);
        isExplosion = true;
    }
}
