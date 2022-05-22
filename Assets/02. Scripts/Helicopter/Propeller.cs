using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("transform.eulerAngles.z = " + transform.eulerAngles.z);
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        if (transform.eulerAngles.z > 360 || transform.eulerAngles.z < 0)
            transform.eulerAngles = new Vector3(-90, 0, 0);
    }
}
