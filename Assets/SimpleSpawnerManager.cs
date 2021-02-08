using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawnerManager : MonoBehaviour
{
    [SerializeField] private SimpleObjectPool pool;
    private Vector3 offset = new Vector3(0, 0, 30);
    public int howManyPendulums;


    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, 1);
        SpawnPendulums(howManyPendulums);
    }

    private void SpawnEnemy()
    {
        GameObject temp = pool.ReturnObject();
        temp.transform.position = transform.position;
        temp.GetComponent<EnemyScript>().ChangeDirection(moveDirection.left);
        temp.SetActive(true);
        transform.position += offset;
        if(transform.position.z > 200)
        {
            transform.position -= offset * 12;
        }
    }

    private void SpawnPendulums(int howManyPendulums)
    {
        float spreading = 280 / howManyPendulums;
        for(int i = 0; i < howManyPendulums; i++)
        {
            GameObject temp = Instantiate(pool.ReturnPendulum());
            temp.transform.position = new Vector3(50, 90, -110 + (spreading * i));
            temp.GetComponent<Pendulu>().SetStartingTime(Random.Range(0f, 2f));
        }
    }
}
