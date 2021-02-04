using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private bool isRolling = false;
    private float scale;
    private float inputThreshold = 0.05f;
    private bool isGrounded;
    private Vector3 gravity = new Vector3(0, -100, 0);
    [SerializeField] private float duration = 1f;
    [SerializeField] private float jumpHeight = 7f;
    [SerializeField] private int gravityMultiply = 500;


    //Cached variable to RollingCube coroutine
    private float angle;
    private float elsapsed;
    private Vector3 point = Vector3.zero;
    private Vector3 axis = Vector3.zero;
    private Vector3 direction = Vector3.zero;
    private Vector3 magnitudeScale;
    private Vector3 movePivotPoint;
    private Vector3 adjustPos;
    private Quaternion adjustRotaition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scale = transform.localScale.x / 2;
        magnitudeScale = new Vector3(0, -0.5f, 0) * transform.localScale.x;
        movePivotPoint = new Vector3(0, -scale, 0);
    }

    private void FixedUpdate()
    {
        if (!isGrounded)
        {
            rb.AddForce(gravity * gravityMultiply * Time.deltaTime, ForceMode.Acceleration);
        }
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if(!isRolling && (Mathf.Abs(x) > inputThreshold || Mathf.Abs(y) > inputThreshold) && isGrounded)
        {
            isRolling = true;
            StartCoroutine(RollingCube(x, y));
        }

        if (isGrounded && !isRolling)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            }
        }
    }

    IEnumerator RollingCube(float x, float y)
    {
        elsapsed = 0f;
        angle = 0f;

        if(x != 0)
        {
            axis = Vector3.forward;
            point = x > 0 ?
                transform.position + (Vector3.right * scale) :
                transform.position + (Vector3.left * scale);
            angle = x > 0 ? -90 : 90;
            direction = x > 0 ? Vector3.right : Vector3.left;

        } else if(y != 0)
        {
            axis = Vector3.right;
            point = y > 0 ?
                transform.position + (Vector3.forward * scale) :
                transform.position + (Vector3.back * scale);
            angle = y > 0 ? 90 : -90;
            direction = y > 0 ? Vector3.forward : Vector3.back;
        }

        //Move pivot point to bottom of cube
        point += movePivotPoint;

        //Slightly adjust position
        adjustPos = point + direction * scale - magnitudeScale;

        //Slightly adjust rotation
        adjustRotaition = Quaternion.Euler(direction * 90f);

        while(elsapsed < duration)
        {
            elsapsed += Time.deltaTime;

            transform.RotateAround(
                point,
                axis,
                angle / duration * Time.deltaTime
            );

            yield return null;
        }
        
        //Without this line cube slowly suffocate into ground after couple of moves
        transform.position = adjustPos;

        //Same with rotation, slighlty adjust them
        transform.rotation = adjustRotaition;

        isRolling = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
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
