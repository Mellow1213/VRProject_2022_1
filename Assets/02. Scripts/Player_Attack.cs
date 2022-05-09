using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public GameObject bullet_Prefab;
    public GameObject fire_Pos;

    float reloadRate;
    Transform firepos;  
    
    void Start()
    {
        firepos = fire_Pos.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        reloadRate -= Time.deltaTime;
        if (Input.GetMouseButton(0) && reloadRate < 0)
        {
            Fire();
        }

    }


    void Fire()
    {
        Instantiate(bullet_Prefab, firepos.transform.position, firepos.transform.rotation);
        reloadRate = 0.07f;
    }

}
