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

    [SerializeField] private GameObject _cubePrefab, _spherePrefab, _cylinderPrefab;

    [SerializeField] private List<GameObject> _movingEnvObstaclePool = new List<GameObject>();


    private void Awake()
    {
        // initialize singleton while scene loads
        _instance = this;
    }


    private void Start()
    {
        // populate obstacle pool; how many want to create in pool
        // this will return a list
        _movingEnvObstaclePool = GenerateMovingObstacles(5);
    }


    // pregenerate list of obstacles using obstacles in obstacle prefab list
    // generate list to store and reuse objects
    List<GameObject> GenerateMovingObstacles(int numOfObstacles)
    {
        for (int i = 0; i < numOfObstacles; i++)
        {
            // create obstacle
            GameObject obstacle = Instantiate(_cubePrefab);

            // put the generated obstacles into the obstacle container
            obstacle.transform.parent = _obstacleContainer.transform;

            // turn on/off visibility of obstacles
            //obstacle.SetActive(false);
            obstacle.SetActive(true);

            // add obstacles to obstacle pool
            _movingEnvObstaclePool.Add(obstacle);
        }

        // return obstacle pool
        return _movingEnvObstaclePool;
    }


    // ignore below to hold limit to 8 objects in pool
    public GameObject RequestObstacle() // if list is full create obj dynamically
    {
        // make obstacle active
        // reassign based on where spawn manager needs it
        // loop through obstacle list
        // chk for inactive obstacle

        foreach (var obstacle in _movingEnvObstaclePool)
        {
            if (obstacle.activeInHierarchy == false)
            {
                // obstacle is available
                // make sure obstacle is active
                // return to user
                obstacle.SetActive(true);
                return obstacle;
            }
        }

        // if made it here need generate more obstacles
        // found obstacle? set it active and return it to the spawn manager
        // if no obstacles available i.e. all turned on
        // nn generate more obstacles and run RequestObstacle method
        // when go beyond num of obstacles created we will continue using pool
        GameObject newObstacle = Instantiate(_cubePrefab);
        newObstacle.transform.parent = _obstacleContainer.transform; // go's parent
        _movingEnvObstaclePool.Add(newObstacle);

        // return new obstacle to spawn manager
        return newObstacle;

        //return null;
    }
}