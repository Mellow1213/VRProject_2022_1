using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerCtrl : MonoBehaviour
{

    public GameObject spine;
    public GameObject head;

    public GameObject view01;
    public GameObject view02;
    public GameObject view03;
    public GameObject view;

    AudioSource audiosource;
    public AudioClip normalFire;
    public AudioClip assistGauge;
    public AudioClip assistFire;

    float fireDelay = 0f;

    public GameObject firePos;
    public GameObject gaugeEffect;
    public GameObject fireEffect;

    Quaternion originRotation;
    Quaternion recoilRotation;
    Quaternion assistRotation;
    Quaternion assistFireRotation;

    bool isRecoil = false; // 반동
    bool isAssist = false;
    bool isAssistFired = false;
    private bool isStared = false; // 플레이어가 동료를 보고 있는지

    public void setIsStared(bool isStared)
    {
        this.isStared = isStared;
    }

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        originRotation = Quaternion.Euler(new Vector3(4.86f, -2.30f, 5.73f));
        recoilRotation = Quaternion.Euler(new Vector3(-6.01f, -3.39f, 5.74f));
        assistRotation = Quaternion.Euler(new Vector3(-28.40f, -5.89f, 6.49f));
        assistFireRotation = Quaternion.Euler(new Vector3(-34.886f, -6.788f, 6.966f));
    }

    // Update is called once per frame
    void Update()
    {
        head.transform.LookAt(view.transform);

        if (isAssist)
        {
            view.transform.position = Vector3.MoveTowards(view.transform.position, view03.transform.position, 0.15f);
        }

        else if (!isStared)
        {
            fireDelay += Time.deltaTime;
            view.transform.position = Vector3.MoveTowards(view.transform.position, view01.transform.position, 0.2f);
        }
        else
        {
            view.transform.position = Vector3.MoveTowards(view.transform.position, view02.transform.position, 0.2f);
        }

        if (Input.GetKeyDown(KeyCode.I))
            isStared = !isStared;



        if (fireDelay > 8f)
        {
            audiosource.PlayOneShot(normalFire);
            isRecoil = true;
            fireDelay = 0f;
        }
        else if (fireDelay > 0.5f)
            isRecoil = false;


        if (isAssist)
            if (!isAssistFired)
                spine.transform.localRotation = Quaternion.Lerp(spine.transform.localRotation, assistRotation, 0.05f);
            else
                spine.transform.localRotation = Quaternion.Lerp(spine.transform.localRotation, assistFireRotation, 0.05f);

        else if (isRecoil)
            spine.transform.localRotation = Quaternion.Lerp(spine.transform.localRotation, recoilRotation, 0.1f);
        else
            spine.transform.localRotation = Quaternion.Lerp(spine.transform.localRotation, originRotation, 0.01f);

    }
    public void AssistFire()
    {
        if (GameManager.Instance.score >= 100)
        {
            isAssist = true;
            StartCoroutine(Fire());
            Debug.Log("지원사격 발동");
        }
        else
        {
            Debug.Log("모자르다고!");
        }
    }

    IEnumerator Fire()
    {

        audiosource.PlayOneShot(assistGauge);
        GameObject a = Instantiate(gaugeEffect);
        a.transform.SetParent(firePos.transform, false);
        Debug.Log("발사 준비 이펙트");
        yield return new WaitForSeconds(3.5f);
        isAssistFired = true;
        audiosource.PlayOneShot(assistFire);
        GameObject b = Instantiate(fireEffect);
        b.transform.SetParent(firePos.transform, false);
        Debug.Log("발사 이펙트!!");
        yield return new WaitForSeconds(0.8f);
        isAssistFired = false;
        isAssist = false;
    }
}
