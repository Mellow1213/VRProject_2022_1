using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlayerLook : MonoBehaviour
{
    GameObject player;
    Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
    }
}
