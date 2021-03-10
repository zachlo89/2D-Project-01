using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private GameObject objectToFollow;
    private PlayerHealth playerHealth;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float aggroDistance = 40;
    private EnemyPatrol patrol;
    private Rigidbody rb;
    private float gravity = 80;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        patrol = GetComponent<EnemyPatrol>();
        if (objectToFollow == null)
        {
            objectToFollow = GameObject.FindGameObjectWithTag("Player");
        }
        playerHealth = objectToFollow.GetComponent<PlayerHealth>();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, objectToFollow.transform.position) <= aggroDistance && playerHealth.currentHealth > 0)
        {
            transform.LookAt(objectToFollow.transform);
            Vector3 direction = (objectToFollow.transform.position - transform.position).normalized * speed;
            direction.y = -gravity;
            rb.velocity = direction;
            patrol.enabled = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroDistance);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Killable")){
            Destroy(gameObject);
        }
    }
}
