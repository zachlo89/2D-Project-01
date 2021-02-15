using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Vector3 _spawnPoint = new Vector3();

    [SerializeField] private int _objSpawnIntervalTime;

    private bool _playerAlive = true;
    

    void Update()
    {
        StartCoroutine(ObstacleSpawnRoutine());
    }


    // spawn obstacles every 3 seconds
    IEnumerator ObstacleSpawnRoutine()
    {
        while (_playerAlive == true) // while player alive etc
        {
            // comm with pool manager through singleton instance to get obstacle
            // create a ref to allow for flexibility like reposition, scale etc.
            // this grabs obstacle from pool
            GameObject obstacle = MovingEnvObstaclePoolManager.Instance.RequestObstacle();

            // request obstacle/more obstacles
            obstacle.transform.position = _spawnPoint;

            yield return new WaitForSeconds(_objSpawnIntervalTime);

            _playerAlive = false;
        }
    }
}
