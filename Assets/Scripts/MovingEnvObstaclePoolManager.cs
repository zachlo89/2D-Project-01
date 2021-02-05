using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnvObstaclePoolManager: MonoBehaviour
{
    // request obj needed
    // recycle obj
    // turn class into singleton for easy access

    // allows us to run across all classes and hv private ref to only this class
    private static MovingEnvObstaclePoolManager _instance;


    // Access above private ref through public property which returns instance
    // allows other classes to comm w/ this class
    // property Instance; when get MovEnvObstacleMan we get it, but not set
    public static MovingEnvObstaclePoolManager Instance
    {
        // get instance
        get
        {
            // null chk before return instance
            // if pool manager is null when trying to access it or get info from it then show error msg
            if (_instance == null)
            {
                Debug.LogError("The Moving Env Obstacle Pool Manager is NULL");
            }

            // if not null
            return _instance;
        }
    }


    // container to organize and store pool of obj instantiated
    [SerializeField] private GameObject _obstacleContainer;

    [SerializeField] private GameObject _cubePrefab;
    //[SerializeField] private GameObject _cubePrefab, _spherePrefab, _cylinderPrefab;

    // nn to access this list from another class
    [SerializeField] private List<GameObject> _movingEnvObstaclePool = new List<GameObject>();


    private void Awake()
    {
        // initialize singleton while scene loads
        _instance = this;
    }


    private void Start()
    {
        // populate obstacle pool List; how many want to create in pool
        // this will return a list
        _movingEnvObstaclePool = GenerateMovingObstacles(3);
    }


    // pregenerate list of obstacles using obstacles in obstacle prefab list
    // generate list to store and reuse objects
    // helper method to retrieve objects from list
    // done so that List storing obstacles can stay private
    List<GameObject> GenerateMovingObstacles(int numOfObstacles)
    {
        // loop so run as many times obstacles u want to create
        for (int i = 0; i < numOfObstacles; i++)
        {
            // create obstacle; instantiate clone
            GameObject obstacle = Instantiate(_cubePrefab);

            obstacle.transform.parent = _obstacleContainer.transform;

            // turn on/off visibility of obstacles
            obstacle.SetActive(true);

            // add obstacles to obstacle pool List
            _movingEnvObstaclePool.Add(obstacle);
        }

        // return obstacle pool
        return _movingEnvObstaclePool;
    }


    // if list is full create obj dynamically
    // helper method to request bullet
    // SpawnManager comms with obj pool vis this method "Request obstacle"
    public GameObject RequestObstacle()
    {
        // make obstacle active
        // reassign based on where spawn manager needs it
        // loop through obstacle list
        // chk for in-active obstacle

        foreach (var obstacle in _movingEnvObstaclePool)
        {
            if (obstacle.activeInHierarchy == false)
            {
                // obstacle is available? 
                // if yes then status of it in-active is false
                // make sure obstacle is active
                // return/give obstacle to spawnManager
                obstacle.SetActive(true);
                return obstacle;
            }
        }

        // if made it here need generate more obstacles
        // found obstacle? set it active and return it to the spawn manager
        // if no obstacles available i.e. all turned on
        // nn generate more obstacles and run RequestObstacle method so there are obstacles constantly spawned
        // when go beyond num of obstacles created we will continue using pool
        GameObject newObstacle = Instantiate(_cubePrefab);
        newObstacle.transform.parent = _obstacleContainer.transform; // add it to container to keep neat
        _movingEnvObstaclePool.Add(newObstacle);

        // return new obstacle to spawn manager
        return newObstacle;

        //return null;
    }
}