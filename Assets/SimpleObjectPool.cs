using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrototype;
    [SerializeField] private GameObject pendulum;
    private List<GameObject> enemyPool = new List<GameObject>();

    private void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject temp = Instantiate(enemyPrototype);
            temp.SetActive(false);
            enemyPool.Add(temp);
        }
    }

    public GameObject ReturnObject()
    {
        // Get in active game object from pool
        GameObject temp = null;
        for (int i = 0; i < enemyPool.Count; i++)
        {
            if (!enemyPool[i].activeInHierarchy)
            {
                temp = enemyPool[i];
                break;
            }
        }
        //Just for safety
        //If every possible object in pool is active create new object
        if (temp == null)
        {
            temp = Instantiate(enemyPrototype);
            temp.SetActive(false);
            enemyPool.Add(temp);
        }
        return temp;
    }

    public GameObject ReturnPendulum()
    {
        return pendulum;
    }
}
