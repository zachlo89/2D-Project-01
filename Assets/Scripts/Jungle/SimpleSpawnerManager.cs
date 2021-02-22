using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawnerManager : MonoBehaviour
{
    [SerializeField] private SimpleObjectPool _pool;
    //[SerializeField] private EnemyScript _enemyScript;

    private Vector3 _baseOffset = new Vector3(0, 0, 2); // default distance between obj spawned
    private Vector3 _offsetPos1 = new Vector3(15, 0.25f, 5); // prefab obj spawn pos aka logs
    private Vector3 _offsetPos2 = new Vector3(15, 0.25f, 3);
    private Vector3 _offsetPos3 = new Vector3(15, 0.25f, 2);

    //public int howManyPendulums;
    //private GameObject _spawnPoint;


    private void Start()
    {
        //if (_enemyScript != null)
        //{
        //    _enemyScript = 
        //}

        InvokeRepeating("SpawnEnemyRow1", 0.5f, 0.8f);
        InvokeRepeating("SpawnEnemyRow2", 0.5f, 0.8f);
        InvokeRepeating("SpawnEnemyRow3", 0.5f, 0.8f);
        //SpawnPendulums(howManyPendulums);
    }

    private void SpawnEnemyRow1()
    {
        GameObject objFromPool = _pool.ReturnObject();
        objFromPool.transform.position = transform.position + _offsetPos1;
        objFromPool.GetComponent<EnemyScript>().ChangeDirection(moveDirection.left);
        objFromPool.SetActive(true);

        _offsetPos1 += _baseOffset;

        if (_offsetPos1.z >= -9)
        {
            _offsetPos1.z = -14;
        }
    }

    private void SpawnEnemyRow2()
    {
        GameObject objFromPool = _pool.ReturnObject();
        objFromPool.transform.position = transform.position + _offsetPos2;
        objFromPool.GetComponent<EnemyScript>().ChangeDirection(moveDirection.left);
        objFromPool.SetActive(true);

        _offsetPos2 += _baseOffset;

        if (_offsetPos2.z >= 13.5f)
        {
            _offsetPos2.z = 8;
        }
    }

    private void SpawnEnemyRow3()
    {
        GameObject objFromPool = _pool.ReturnObject();
        objFromPool.transform.position = transform.position + _offsetPos3;
        objFromPool.GetComponent<EnemyScript>().ChangeDirection(moveDirection.left);
        objFromPool.SetActive(true);

        _offsetPos3 += _baseOffset;

        if (_offsetPos3.z >= 35)
        {
            _offsetPos3.z = 23;
        }
    }

    //private void SpawnPendulums(int howManyPendulums)
    //{
    //    float spreading = 280 / howManyPendulums;

    //    for (int i = 0; i < howManyPendulums; i++)
    //    {
    //        GameObject temp = Instantiate(_pool.ReturnPendulum());
    //        temp.transform.position = new Vector3(50, 90, -110 + (spreading * i));
    //        temp.GetComponent<Pendulu>().SetStartingTime(Random.Range(0f, 2f));
    //    }
    //}
}
