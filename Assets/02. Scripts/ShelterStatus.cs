using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterStatus : MonoBehaviour
{
    public GameObject explosion;
    private Transform shelter;
    private int HP;
    public static bool isBoom;

    // Start is called before the first frame update
    void Start()
    {
        shelter = this.transform.parent;
        HP = 50;
        isBoom = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            HP -= 0;
        if (HP <= 0)
            Explosion();
    }

    void Explosion()
    {
        this.gameObject.SetActive(false);
        explosion.SetActive(true);
        Destroy(shelter.gameObject, 3.0f);
        isBoom = true;
    }
}
