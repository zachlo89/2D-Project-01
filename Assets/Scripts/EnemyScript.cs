using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float speed;
    private Vector3 direction;
    [SerializeField] private float minSpeed, maxSpeed;
    [SerializeField] private float maxLeftDistance, maxRightDistance;
    [SerializeField] private moveDirection moveDir = moveDirection.left;

    public enum moveDirection
    {
        left,
        right
    }

    //Designate random speed and decide about direction
    //OnEnable work similar to Start method, but is called everytime object is setActive
    private void OnEnable()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        if (moveDir == moveDirection.left)
        {
            direction = Vector3.left;
        }
        else direction = Vector3.right;
    }
    // Opposite of onEnable method, reset everything to default
    private void OnDisable()
    {
        moveDir = moveDirection.left;
    }

    private void FixedUpdate()
    {
        //Very simple script to move object nicely, can introduce some rotation later on when we'll have some asstes, now can't see any difference
        transform.Translate(direction * speed * Time.deltaTime);
        if(transform.position.x < maxLeftDistance || transform.position.x > maxRightDistance)
        {
            gameObject.SetActive(false);
        }
    }

    //In case object will have to spawn from left, remember to use it in case you want spawn them from left to right not right to left
    public void ChangeDirection(moveDirection dir)
    {
        moveDir = dir;
    }
}
