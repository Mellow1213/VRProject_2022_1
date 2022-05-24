using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunRotateFix : MonoBehaviour
{
    public GameObject gun;

    public GameObject player;
    public GameObject helicopter;

    bool bol = true;

    Vector3 originPosition;
    Vector3 originRotation;
    // Start is called before the first frame update
    void Start()
    {
        originPosition = gun.transform.localPosition;
        originRotation = gun.transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("bol = " + bol);
            bol = !bol;
        }

        if (bol)
        {
            gun.transform.SetParent(player.transform);
            gun.transform.localPosition = originPosition;
            gun.transform.localRotation = Quaternion.Euler(originRotation);
        }
        else
            gun.transform.SetParent(helicopter.transform);
    }
}
