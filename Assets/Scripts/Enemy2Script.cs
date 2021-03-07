using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Script : MonoBehaviour
{
    [SerializeField] private GameObject objectToFollow;
    private PlayerHealth playerHealth;
    [SerializeField] private float speed = 3f;

    private void Start()
    {
        playerHealth = objectToFollow.GetComponent<PlayerHealth>();   
    }

    private void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, objectToFollow.transform.position) < 500 && playerHealth.currentHealth > 0)
        {
            transform.LookAt(objectToFollow.transform);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
