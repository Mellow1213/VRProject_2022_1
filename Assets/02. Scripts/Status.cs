using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    [SerializeField] private int HP; // Inspector에서 수정 금지!!
    public GameObject DeathEffect;
    bool deathEffectPlayed = false;
    public AudioClip deathSound;

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

    public int score;
    void Destroyed()
    {
        
        switch (gameObject.name)
        {
            case "FlyerEnemy(Clone)":
                score = 100;
                flyerDestroy(gameObject);
                GetComponent<EnemyFire>().enabled = false;
                break;
            case "FlyerEnemy2(Clone)":
                score = 50;
                flyerDestroy(gameObject);
                GetComponent<EnemyFire_immidiate>().enabled = false;
                break;
            case "FlyerEnemy3(Clone)":
                score = 20;
                flyerDestroy(gameObject);
                GetComponent<EnemyFire_immidiate>().enabled = false;
                break;
            default:
                Destroy(gameObject);
                break;
        }
        if (!deathEffectPlayed)
        {
            Debug.Log(gameObject.name +" 파괴, 점수 + " + score);
            GameManager.Instance.score += score;
            Instantiate(DeathEffect, transform.position, transform.rotation);
            deathEffectPlayed = true;
            GameObject.Find("Player").GetComponent<AudioSource>().PlayOneShot(deathSound);
        }
    }

    void flyerDestroy(GameObject enemy)
    {
        enemy.GetComponent<EnemyMove>().enabled = false;
        enemy.transform.Find("Collider").GetComponent<FlyEnemyLootAt>().enabled = false;
        enemy.transform.Find("Collider").GetComponent<BoxCollider>().enabled = false;
        Rigidbody r = enemy.GetComponent<Rigidbody>();
        r.isKinematic = false;
        r.useGravity = true;
        r.AddForce(30, -50, 30);
        Destroy(gameObject, 3.0f);
    }

}
