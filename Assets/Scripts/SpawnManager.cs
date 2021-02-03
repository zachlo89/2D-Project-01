using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Vector3 _spawnPoint = new Vector3();

    public List<GameObject> obstacles = new List<GameObject>();

    [SerializeField] private float _objSpawnInterval = 3.0f;
    

    void Start()
    {
        //foreach (var item in obstacles)
        //{

        //}
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
            foreach (var item in obstacles)
            {
                Instantiate(_obstacles[i], _spawnPoint, );
            }
            yield return new WaitForSeconds(_objSpawnInterval);
            
        }
    }
  
}
