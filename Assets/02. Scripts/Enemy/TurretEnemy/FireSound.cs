using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSound : MonoBehaviour
{
    public AudioClip fireSound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            Firesound();
    }

    IEnumerator Firesound()
    {
        yield return new WaitForSeconds(10.0f);
        Debug.Log("소리");
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(fireSound);
    }
}
