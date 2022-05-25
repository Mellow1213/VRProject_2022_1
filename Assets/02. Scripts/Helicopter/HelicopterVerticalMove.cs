using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterVerticalMove : MonoBehaviour
{
    public float moveSpeed = 50f;
    float originYPos;

    HelicopterMove hm;
    // Start is called before the first frame update
    void Start()
    {
        originYPos = transform.position.y;
        hm = GetComponent<HelicopterMove>();
    }

    // Update is called once per frame
    void Update()
    {
        Up(340f);
    }

    void Up(float height)
    {
        if (transform.position.y - originYPos < height)
            transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
        else
        {
            hm.enabled = true;
            this.enabled = false;
        }
        transform.Rotate(Vector3.up * Time.deltaTime * 5f);
    }

}
