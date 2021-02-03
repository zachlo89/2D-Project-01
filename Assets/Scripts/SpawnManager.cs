using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Vector3 _spawnPoint = new Vector3();

    [SerializeField] private float _objSpawnIntervalTime = 3.0f;
    

    void Start()
    {

    }

    void Update()
    {
        StartCoroutine(ObstacleSpawnRoutine());
    }

    // spawn obstacles every 3 seconds
    IEnumerator ObstacleSpawnRoutine()
    {
        while (true) // while player alive
        {
            yield return new WaitForSeconds(_objSpawnIntervalTime);
        }
    }
}
