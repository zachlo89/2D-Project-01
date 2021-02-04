using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("Hide", 1);
    }

    void Hide()
    {
        //Debug.Log("Hiding GameObject");

        // recycle gameobject
        this.gameObject.SetActive(false);
    }
}