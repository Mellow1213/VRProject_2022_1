using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress_Stage01 : MonoBehaviour
{
    public GameObject[] maps;

    public GameObject[] shelters;

    public void DestroyMap(int index)
    {
        Destroy(maps[index]);
    }

    public void CreateMap(int index)
    {
        maps[index].SetActive(true);
    }
}
