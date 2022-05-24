using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a : MonoBehaviour
{
    public GameObject flyerEnemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("FlyerSpawn (D)");
        if (Input.GetKeyDown(KeyCode.D))
            Instantiate(flyerEnemy);

    }
}
