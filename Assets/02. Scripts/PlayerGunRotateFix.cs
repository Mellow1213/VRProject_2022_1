using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunRotateFix : MonoBehaviour
{
    public GameObject gun;

    public GameObject player;
    public GameObject helicopter;

    private bool permissionToFire;

    Vector3 originPosition;
    Vector3 originRotation;

    float timer= 0f;
    
    public bool getPermissionToFire() { return permissionToFire; }  


    // Start is called before the first frame update
    void Start()
    {
        originPosition = gun.transform.localPosition;
        originRotation = gun.transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("timer = " + timer);
        RaycastHit hit;

        int layerMask = 1 << 9; // 레이어 마스크를 비트 연산을 통해 GunFixArea만 인식하도록 설정하는 변수
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 30f, layerMask))
        {
            permissionToFire = true;
            gun.transform.SetParent(player.transform);
            gun.transform.localPosition = SetLerpPosition(gun, originPosition, 0.1f);
            gun.transform.localRotation = Quaternion.Euler(originRotation);//SetLerpRotation(gun, originRotation, 0.1f);//
        }
        else
        {
            timer = 0f;
            permissionToFire = false;
            gun.transform.SetParent(helicopter.transform);
        }

    }
    Vector3 SetLerpPosition(GameObject origin, Vector3 target, float t)
    {
        timer += Time.deltaTime;
        if (timer >= 2f)
        {
            Debug.Log("고정이동중");
            return target;
        }
        else
        {
            Debug.Log("Lerp이동중");
            return new Vector3(Mathf.Lerp(origin.transform.localPosition.x, target.x, t), Mathf.Lerp(origin.transform.localPosition.y, target.y, t), Mathf.Lerp(origin.transform.localPosition.z, target.z, t));
        }       
    }    
}
