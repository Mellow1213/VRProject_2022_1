using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattern : MonoBehaviour
{

    float timer = 0f;
    int patternIndex;

    public GameObject[] firePos;
    public GameObject[] enemy;
    public GameObject barrier;

    public GameObject Missile;
    // Start is called before the first frame update
    void Start()
    {
        patternIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer > 25)
        {
            StartCoroutine(DoPattern());
            patternIndex = Random.Range(1, 5);
            timer = 0f;
        }
    }

    IEnumerator DoPattern()
    {
        switch (patternIndex)
        {
            case 1:
                Pattern02();
                break;
            case 2:
                Pattern03();
                break;
            case 3:
                Pattern04();
                break;
            case 4:
                Pattern05();
                break;
        }
        yield return null;
    }

    void Pattern02()
    {
        Debug.Log("패턴2");
        Instantiate(enemy[0], transform.position, transform.rotation);
    }
    void Pattern03()
    {
        Debug.Log("패턴3");
        Instantiate(enemy[1], transform.position, transform.rotation);
        Instantiate(enemy[1], transform.position, transform.rotation);
    }
    void Pattern04()
    {
        Debug.Log("패턴4");
        Instantiate(enemy[2], transform.position, transform.rotation);
        Instantiate(enemy[2], transform.position, transform.rotation);
    }
    void Pattern05()
    {
        Instantiate(barrier, transform.position, transform.rotation);
    }
}
