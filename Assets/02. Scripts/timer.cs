using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    float timefloated = 0;
    float timeas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timefloated += Time.deltaTime;
        if(Input.GetMouseButtonDown(0)){

            Debug.Log("누름");
            timeas = timefloated;    

        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("뗌");
            Debug.Log("지연 시간 : " + (timefloated - timeas));
        }
    }
}
