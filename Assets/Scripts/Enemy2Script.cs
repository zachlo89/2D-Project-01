using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Script : MonoBehaviour
{
    [SerializeField] private GameObject objectToFollow;
    private PlayerHealth playerHealth;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float aggroDistance = 500;
    private EnemyPatrol patrol;

    private void Start()
    {
        patrol = GetComponent<EnemyPatrol>();
        if(objectToFollow == null)
        {
            objectToFollow = GameObject.FindGameObjectWithTag("Player");
        }
        playerHealth = objectToFollow.GetComponent<PlayerHealth>();
    }

    private void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, objectToFollow.transform.position) < aggroDistance && playerHealth.currentHealth > 0)
        {
            transform.LookAt(objectToFollow.transform);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            patrol.AggroOn(false);
        } else
        {
            patrol.AggroOn(true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroDistance);
    }
}
