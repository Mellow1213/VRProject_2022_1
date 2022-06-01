using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountLeftEnemy : MonoBehaviour
{
    float timer = 0f;
    GameObject[] leftEnemy;

    public TextMeshProUGUI leftEnemyUI;
    public TextMeshProUGUI[] shelterHP;
    public TextMeshProUGUI playerHPUI;

    HelicopterMove hm;
    Progress_Stage01 ps;


    ShelterStatus ss1;
    ShelterStatus ss2;
    ShelterStatus ss3;

    public float playerHP;
    // Start is called before the first frame update
    void Start()
    {
        hm = GetComponent<HelicopterMove>();
        ps = GameObject.Find("ProgressManager").GetComponent<Progress_Stage01>();
        SearchEnemy();
        playerHP = 100f;
        ss1 = ps.shelters[0].transform.GetChild(1).GetComponent<ShelterStatus>();
        ss2 = ps.shelters[1].transform.GetChild(0).GetComponent<ShelterStatus>();
        ss3 = ps.shelters[2].transform.GetChild(0).GetComponent<ShelterStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.unscaledDeltaTime;
        if(timer > 1f)
        {
            SearchEnemy();
            ShelterHP();
            PlayerHP();
            timer = 0;
        }

        //Debug.Log("leftEnemy 숫자 = " + leftEnemy.Length);
        if (leftEnemy.Length <= 0)
            hm.loopEndSwitch = true;
        else
            hm.loopEndSwitch = false;

        Debug.Log("ps.shelters[2].activeSelf = " + ps.shelters[2].activeSelf);

    }

    void SearchEnemy()
    {
        leftEnemy = GameObject.FindGameObjectsWithTag("Turret");
        leftEnemyUI.text = "Left Enemy\n" + (leftEnemy.Length);
    }

    void ShelterHP()
    {

        shelterHP[0].text = "Shelter1 / " + ss1.getShelterHP();


        if (ps.shelters[1].transform.parent.gameObject.activeSelf)
            shelterHP[1].text = "Shelter2 / " + ss2.getShelterHP();
        else
            shelterHP[1].text = "Shelter2 / " + "Not Detected";


        if (ps.shelters[2].transform.parent.gameObject.activeSelf)
            shelterHP[2].text = "Shelter3 / " + ss3.getShelterHP();
        else
            shelterHP[2].text = "Shelter3 / " + "Not Detected";
    }

    void PlayerHP()
    {
        playerHPUI.text = "Player Health\n" + playerHP;
    }
}
