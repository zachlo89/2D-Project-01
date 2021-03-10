using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Vector3 patrolPoint;
    [SerializeField] private float speed;
    private Vector3 startingPosition;
    private bool shouldPatrol;
    private bool toPatrolPoint;

    void Start()
    {
        toPatrolPoint = true;
        shouldPatrol = true;
        startingPosition = transform.position;
    }

    public void AggroOn(bool agro)
    {
        if (agro != shouldPatrol)
        {
            shouldPatrol = agro;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shouldPatrol)
        {
            if (toPatrolPoint)
            {
                transform.LookAt(patrolPoint);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);

                if (Vector3.Distance(transform.position, patrolPoint) < 5)
                {
                    toPatrolPoint = false;
                }
            }
            else
            {
                transform.LookAt(startingPosition);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);

                if (Vector3.Distance(transform.position, startingPosition) < 5)
                {
                    toPatrolPoint = true;
                }
            }
        }
    }
}
