using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawnerManager : MonoBehaviour
{
    [SerializeField] private SimpleObjectPool _pool;
    private Vector3 _baseOffset = new Vector3(0, 0, 5); // default distance between next obj spawned
    private Vector3 _offset = new Vector3(0, 0, 25);
    public int howManyPendulums;

    // private GameObject _spawnPoint;


    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0.5f, 0.4f);
        SpawnPendulums(howManyPendulums);
    }

    private void SpawnEnemy()
    {
        GameObject temp = _pool.ReturnObject();
        temp.transform.position = transform.position + _offset;
        temp.GetComponent<EnemyScript>().ChangeDirection(moveDirection.left);
        temp.SetActive(true);

        _offset += _baseOffset;
        if (_offset.z > 100)
        {
            _offset.z = 0;
        }
    }

    private void SpawnPendulums(int howManyPendulums)
    {
        float spreading = 280 / howManyPendulums;

        for (int i = 0; i < howManyPendulums; i++)
        {
            GameObject temp = Instantiate(_pool.ReturnPendulum());
            temp.transform.position = new Vector3(50, 90, -110 + (spreading * i));
            temp.GetComponent<Pendulu>().SetStartingTime(Random.Range(0f, 2f));
        }
    }
}
