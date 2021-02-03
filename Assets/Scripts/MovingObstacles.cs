using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacles : MonoBehaviour
{
    [SerializeField] private GameObject cylPrefab, cubePrefab, spherePrefab;


    void Start()
    {
        if (cylPrefab != null)
        {
            cylPrefab = GetComponent<GameObject>();
        }
        
    }

   
    void Update()
    {
        
    }
}
