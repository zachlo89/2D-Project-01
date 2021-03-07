using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerV3 : MonoBehaviour
{
    private Rigidbody rb;
    public bool isGrounded = false;
    private Vector3 gravity = new Vector3(0, -100, 0);
    private Vector3 horizontalMovements = new Vector3(100, 0, 0);
    private Vector3 verticalMovements = new Vector3(0, 0, 100);
    private Vector3 direction = Vector3.zero;

    [SerializeField] private float speed = 500;
    [SerializeField] private float jumpHeight = 2000f;
    [SerializeField] private int gravityMultiply = 500;

    private float x;
    private float y;

    private bool canDoubleJump = true;

    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if (canDoubleJump && !isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                animator.SetTrigger("doubleJump");
                canDoubleJump = false;
            }
        }

        if (isGrounded && canDoubleJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                animator.SetBool("isGrounded", false);
                isGrounded = false;
            }
        }
    }

    private void FixedUpdate()
    {
        direction = (horizontalMovements * x) + (verticalMovements * y);
        animator.SetFloat("runningVertically", y);
        animator.SetFloat("runningHorizontaly", x);
        transform.Translate(direction * speed * Time.deltaTime);
        if (!isGrounded)
        {
            rb.AddForce(gravity * gravityMultiply * Time.deltaTime, ForceMode.Acceleration);
        }
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canDoubleJump = true;
            isGrounded = true;
            animator.SetBool("isGrounded", isGrounded);
        }
        if(other.gameObject.tag == "Finish")
        {
            animator.SetFloat("runningVertically", 0);
            animator.SetFloat("runningHorizontaly", 0);
            animator.SetBool("isGrounded", true);
            animator.SetTrigger("gameWon");
            other.gameObject.GetComponent<LevelCompleted>().Win();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            canDoubleJump = true;
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
