using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountLeftEnemy : MonoBehaviour
{
    float timer = 0f;
    GameObject[] leftEnemy;

    HelicopterMove hm;
    // Start is called before the first frame update
    void Start()
    {
        hm = GetComponent<HelicopterMove>();
        SearchEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.unscaledDeltaTime;
        if(timer > 3f)
        {
            SearchEnemy();
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
    }

}
