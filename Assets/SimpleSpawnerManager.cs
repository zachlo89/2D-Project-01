using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawnerManager : MonoBehaviour
{
    [SerializeField] private SimpleObjectPool pool;
    private Vector3 baseOffset = new Vector3(0, 0, 30);
    private Vector3 offset = new Vector3(0, 0, 30);
    public int howManyPendulums;


    private void Start()
    {
        InvokeRepeating("SpawnEnemy", .5f, .4f);
        SpawnPendulums(howManyPendulums);
    }

    private void SpawnEnemy()
    {
        GameObject temp = pool.ReturnObject();
        temp.transform.position = transform.position + (offset);
        temp.GetComponent<EnemyScript>().ChangeDirection(moveDirection.left);
        temp.SetActive(true);
        offset += baseOffset;
        if(offset.z > 300)
        {
            offset.z = 0;
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
