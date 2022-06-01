using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountLeftEnemy : MonoBehaviour
{
    float timer = 0f;
    GameObject[] leftEnemy;

    public TextMeshProUGUI leftEnemyUI;
    public TextMeshProUGUI shelterHP;
    public TextMeshProUGUI playerHPUI;

    HelicopterMove hm;
    Progress_Stage01 ps;


    public float playerHP;
    // Start is called before the first frame update
    void Start()
    {
        hm = GetComponent<HelicopterMove>();
        ps = GameObject.Find("ProgressManager").GetComponent<Progress_Stage01>();
        SearchEnemy();
        playerHP = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.unscaledDeltaTime;
        if(timer > 1f)
        {
            SearchEnemy();
            //ShelterHP();
            PlayerHP();
            timer = 0;
        }

        //Debug.Log("leftEnemy 숫자 = " + leftEnemy.Length);
        if (leftEnemy.Length <= 0)
            hm.loopEndSwitch = true;
        else
            hm.loopEndSwitch = false;
        
    }

    void SearchEnemy()
    {
        leftEnemy = GameObject.FindGameObjectsWithTag("Turret");
        leftEnemyUI.text = "Left Enemy\n" + (leftEnemy.Length);
    }

    void ShelterHP()
    {
        if ((ps.shelters[0] != null))
            shelterHP.text = "Shelter01\n" + ps.shelters[0].GetComponent<ShelterStatus>().getShelterHP();
        else
            shelterHP.text = "Shelter01\nblowed";
    }

    void PlayerHP()
    {
        playerHPUI.text = "Player Health\n" + playerHP;
    }
}
