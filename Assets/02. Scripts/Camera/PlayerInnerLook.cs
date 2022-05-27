﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInnerLook : MonoBehaviour
{

    PlayerGunRotateFix pgr;
    PartnerCtrl pc;
    public GameObject partner;
    public Image pointerGauge;
    float gaugeTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        pgr = GetComponent<PlayerGunRotateFix>();
        pc = partner.GetComponent<PartnerCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pgr.getPermissionToFire())
        {
            GazeInterface();
        }

    }

    int layerMask;
    void GazeInterface()
    {
        pointerGauge.fillAmount = gaugeTimer;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2));
        
        layerMask = 1 << LayerMask.NameToLayer("Partner");
        gaugeTimer += Time.deltaTime * 0.75f;
        if (Physics.Raycast(ray, 8f))
        {
            if (pointerGauge.fillAmount >= 1.0f)
            {
                pc.setIsStared(true);
                if (Input.GetMouseButtonDown(0))
                {
                    pc.AssistFire();
                }
            }
        }
        else
        {
            pc.setIsStared(false);
            gaugeTimer = 0f;
        }
    }
}