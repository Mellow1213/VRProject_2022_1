using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance is null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);

        score = 1000;
        playerHealth = 200;
        fixedtime = Time.fixedDeltaTime;
    }
    public static GameManager Instance
    {
        get
        {
            if (instance is null)
            {
                return null;
            }
            return instance;
        }
    }

    public int score;
    public int playerHealth;
    public const int Ammo = 200;

    float fixedtime;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0.1f;
            Time.fixedDeltaTime = fixedtime * Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = fixedtime;
        }


    }
}
