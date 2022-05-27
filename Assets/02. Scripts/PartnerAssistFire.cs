using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerAssistFire : MonoBehaviour
{
    public GameObject helicopter;
    public GameObject assistFireObject;

    Transform[] firePos;

    private void Start()
    {
        firePos = transform.GetComponentsInChildren<Transform>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            StartCoroutine(AssistFire());

        transform.position = helicopter.transform.position;
    }

    public IEnumerator AssistFire()
    {
        for (int i =0; i<firePos.Length; i++)
        {
            GameObject a = Instantiate(assistFireObject, firePos[i].position, firePos[i].rotation);
            a.transform.parent = transform;
        }
        yield return null;
    }
}
