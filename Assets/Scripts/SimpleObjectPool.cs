using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectPool : MonoBehaviour
{
    //public static SimpleObjectPool current;
    [SerializeField] private GameObject _enemyPrototype;
    [SerializeField] private GameObject _pendulum;
    [SerializeField] private GameObject _enemyPoolContainer;
    [SerializeField] private int _pooledAmount = 10;
    private List<GameObject> _enemyPool = new List<GameObject>();


    //private void Awake()
    //{
    //    current = this;
    //}

    private void Start()
    {
        for (int i = 0; i < _pooledAmount; i++)
        {
            GameObject obj = Instantiate(_enemyPrototype);
            // placing enemy prototypes in a container to keep it tidy
            obj.transform.parent = _enemyPoolContainer.transform;
            obj.SetActive(false);
            _enemyPool.Add(obj);
        }
    }

    public GameObject ReturnObject()
    {
        // Get in active game object from pool
        GameObject obj = null;

        for (int i = 0; i < _enemyPool.Count; i++)
        {
            if (!_enemyPool[i].activeInHierarchy)
            {
                obj = _enemyPool[i];
                break;
            }
        }
        //Just for safety
        //If every possible object in pool is active create new object
        if (obj == null)
        {
            obj = Instantiate(_enemyPrototype);
            obj.SetActive(false);
            _enemyPool.Add(obj);
        }
        return obj;
    }

    public GameObject ReturnPendulum()
    {
        return _pendulum;
    }
}
