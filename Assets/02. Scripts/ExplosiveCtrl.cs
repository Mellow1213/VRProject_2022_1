
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveCtrl : MonoBehaviour
{
    public GameObject explosion;
    private Transform explosive;
    private Status st;

    // Start is called before the first frame update
    void Start()
    {
        explosive = this.transform.parent;
        st = GetComponent<Status>();
        st.setHP(50);
        explosion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (st.getHP() <= 0)
            Explosion();
        
    }

    public void Explosion()
    {
        this.gameObject.SetActive(false);
        explosion.SetActive(true);
        Destroy(explosive.gameObject, 2.0f);
    }

}
