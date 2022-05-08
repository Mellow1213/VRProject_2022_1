using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public GameObject bullet_Prefab;
    public GameObject fire_Pos;

    Transform firepos;
    
    void Start()
    {
        firepos = fire_Pos.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(bullet_Prefab, firepos.transform.position, firepos.transform.rotation);
    }
}
