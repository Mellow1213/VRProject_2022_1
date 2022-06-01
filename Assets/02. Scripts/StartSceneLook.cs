using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartSceneLook : MonoBehaviour
{
    public Image gauge;
    float timer = 0;
    private Vector3 screencenter;
    public GameObject a;
    // Start is called before the first frame update
    void Start()
    {
        screencenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);   
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(screencenter);
        RaycastHit hit;
        gauge.fillAmount = timer;

        if(Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.transform.name == "GameStart")
            {
                timer += Time.deltaTime;

                if (gauge.fillAmount > 0.99f && Input.GetMouseButtonDown(0))
                {
                    if (!(GameObject.Find("Button") is null))
                    {
                        a.SetActive(true);
                        GameObject.Find("Button").SetActive(false);
                    }
                    else
                        SceneManager.LoadScene("TestScene");
                }

            }
        }
        else
            timer = 0f;
    }
}
