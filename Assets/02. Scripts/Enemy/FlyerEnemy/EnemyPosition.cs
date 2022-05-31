using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyPosition : MonoBehaviour
{
    Transform[] position;
    bool[] emptyPos;


    public void setEmptyPos(bool isEmpty, int index)
    {
        emptyPos[index] = isEmpty;
    }

    public bool getEmptyPos(int index)
    {
        return emptyPos[index];
    }

    public bool isEmptyExist()
    {
        bool flag = false;
        for (int i = 0; i<position.Length; i++)
        {
            if (emptyPos[i] == true)
                flag = true;
        }
        return flag;
    }

    // Start is called before the first frame update
    void Start()
    {
        position = GetComponentsInChildren<Transform>();
        emptyPos = Enumerable.Repeat(true, position.Length).ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Debug.Log("isEmptyExist = " + isEmptyExist());
        for (int i = 0; i<emptyPos.Length; i++)
            Debug.Log("Index "+i+ " is Empty? : " + emptyPos[i]);
        */
    }
}
