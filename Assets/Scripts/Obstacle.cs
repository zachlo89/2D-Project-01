using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int _speed;


    void Update()
    {
        // move minus on x
        // respawn at spawn point once goes off screen
        //transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }


    // similar to Start()
    // hide new obstacles after a few seconds
    // so will see obstacles move then disappear down the path
    // auto called each time go active is true
    void OnEnable()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);

        Invoke("Hide", 3.0f);
    }


    void Hide()
    {
        Debug.Log("Hiding GameObject WORKS!");

        // recycle gameObject
        // this will create the loop effect to cycle through limited
        // num of ostacles
        this.gameObject.SetActive(false);
    }
}