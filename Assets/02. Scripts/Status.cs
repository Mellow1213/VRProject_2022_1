using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    [SerializeField] private int HP; // Inspector에서 수정 금지!!

    private void Start()
    {   
    }

    public int getHP()
    {
        return HP;
    }

    public void setHP(int HP)
    {
        this.HP = HP;
    }

    public void Damaged(int damage)
    {
        this.HP -= damage;
    }

    private void Update()
    {
        if (HP < 0)
        {
            Destroy(gameObject);
        }
    }


}
