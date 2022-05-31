using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlayer : MonoBehaviour
{
    AudioSource audsource;

    float timer = 0;
    public float[] TimingSec;

    Camera maincam;
    public GameObject[] effectObject;
    Material skybox;

    public GameObject screenPos;
    public GameObject targetPos;
    // Start is called before the first frame update
    void Start()
    {
        audsource = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
        maincam = Camera.main.GetComponent<Camera>();
        skybox = RenderSettings.skybox;
        skybox.SetFloat("_Exposure", 0f);
        RenderSettings.ambientIntensity = 0.5f;

        for (int i = 0; i < TimingSec.Length; i++)
            TimingSec[i] -= 0.25f;
    }

    bool isMenuStart = false;
    // Update is called once per frame
    void Update()
    {
        if(audsource.isPlaying)
            MenuStart();

    }

    void MenuStart()
    {
        skybox.SetFloat("_Rotation", timer * 2);
            timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.A))
            Debug.Log("time = " + timer);
        if (audsource.isPlaying)
        {
            if (timer >= TimingSec[0])
                effectObject[0].SetActive(true);
            if (timer >= TimingSec[1])
                effectObject[1].SetActive(true);
            if (timer >= TimingSec[2])
                effectObject[2].SetActive(true);
            if (timer >= TimingSec[3])
            {
                maincam.clearFlags = CameraClearFlags.Skybox;
                skybox.SetFloat("_Exposure", Mathf.Lerp(RenderSettings.skybox.GetFloat("_Exposure"), 1f, 2.5f * Time.deltaTime));
                RenderSettings.ambientIntensity = Mathf.Lerp(RenderSettings.ambientIntensity, 8, 2.5f * Time.deltaTime);
            }
            if (timer >= TimingSec[4])
            {
                effectObject[3].SetActive(true);
                if (screenPos.transform.position.y > 1.5f)
                    screenPos.transform.position = Vector3.Lerp(screenPos.transform.position, targetPos.transform.position, 0.05f);
                else
                {
                    screenPos.transform.position = new Vector3(screenPos.transform.position.x, screenPos.transform.position.y - (Mathf.Sin(timer) * 0.005f), screenPos.transform.position.z);
                }

            }
        }
    }
}
