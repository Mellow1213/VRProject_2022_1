using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject enemyPosition;
    Transform[] enemyPositions;

    Status st;

    EnemyPosition em;
    int index = 0;


    [SerializeField]  private float speed = 1f;
    [SerializeField]  private float length = 1f;
    private float runningTime = 0f;
    private float yPos = 0f;

    // Start is called before the first frame update
    void Start()
    {
        st = GetComponent<Status>();
        enemyPosition = GameObject.Find("EnemyPosition");
        enemyPositions = enemyPosition.GetComponentsInChildren<Transform>();

        em = enemyPosition.GetComponent<EnemyPosition>();


        if (!em.isEmptyExist())
            Destroy(gameObject);
        else
            while (true)
            {
                int random = Random.Range(0, enemyPositions.Length);
                if (em.getEmptyPos(random))
                {
                    index = random;
                    em.setEmptyPos(false, index);
                    break;
                }

            }
    }

    // Update is called once per frame
    void Update()
    {

        //sin함수 값으로 Flyer가 계속 위아래로 공중부양하듯이 연출
        runningTime += Time.deltaTime * speed;
        yPos = Mathf.Sin(runningTime) * length * 0.07f;
        this.transform.localPosition = new Vector3(transform.position.x, transform.position.y + yPos, transform.position.z);

        transform.position = Vector3.Lerp(gameObject.transform.position, enemyPositions[index].position, 1.5f*Time.deltaTime);

    }
    private void FixedUpdate()
    {
        if (st.getHP() <= 0)
            em.setEmptyPos(true, index);
    }

}
