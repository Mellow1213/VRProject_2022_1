using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress_Stage01 : MonoBehaviour
{
    public GameObject[] Maps;

    public void DestroyMap(int index)
    {
        Destroy(Maps[index]);
    }

    public void CreateMap(int index)
    {
        Maps[index].SetActive(true);
    }
}
