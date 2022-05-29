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
        HP -= damage;
    }



    private void FixedUpdate()
    {
        if (HP < 0)
            Destroyed();
    }

    void Destroyed()
    {
        switch (gameObject.name)
        {
            case "FlyerEnemy(Clone)":
                Destroy(gameObject);
                GameManager.Instance.score += 50;
                Debug.Log("FlyerEnemy 파괴, 점수 + 50");
                break;
            default:
                Destroy(gameObject);
                break;
        }
    }
}
