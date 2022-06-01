using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    public int destroyMapIndex;
    public int createMapIndex;

    Progress_Stage01 ps;
    private void Start()
    {
        ps = GameObject.Find("ProgressManager").GetComponent<Progress_Stage01>();   
    }
    public void MapCtrl()
    {
        ps.DestroyMap(destroyMapIndex);
        ps.CreateMap(createMapIndex);
    }
}
