using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Vector3 _spawnPoint = new Vector3();

    [SerializeField] private float _objSpawnIntervalTime = 3.0f;
    

    void Update()
    {
        StartCoroutine(ObstacleSpawnRoutine());
    }

    // spawn obstacles every 3 seconds
    IEnumerator ObstacleSpawnRoutine()
    {
        while (true) // while player alive etc
        {
            // access pool manager through singleton instance to get obstacle
            GameObject obstacle = MovingEnvObstaclePoolManager.Instance.RequestObstacle();

            // request obstacle/more obstacles
            obstacle.transform.position = _spawnPoint;

            yield return new WaitForSeconds(_objSpawnIntervalTime);
        }

        // never get here constant while loop
    }
}
