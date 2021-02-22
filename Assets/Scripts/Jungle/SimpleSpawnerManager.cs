using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawnerManager : MonoBehaviour
{
    [SerializeField] private SimpleObjectPool _pool;
    private Vector3 _baseOffset = new Vector3(0, 0, 2); // default distance between obj spawned
    private Vector3 _offset = new Vector3(10, 0.25f, 5); // prefab obj spawn pos aka logs
    //public int howManyPendulums;
    //private GameObject _spawnPoint;


    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0.5f, 0.8f);
        //SpawnPendulums(howManyPendulums);
    }

    private void SpawnEnemy()
    {
        GameObject objFromPool = _pool.ReturnObject();
        objFromPool.transform.position = transform.position + _offset;
        objFromPool.GetComponent<EnemyScript>().ChangeDirection(moveDirection.left);
        objFromPool.SetActive(true);

        _offset += _baseOffset;

        if (_offset.z >= -9)
        {
            _offset.z = -14;
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
