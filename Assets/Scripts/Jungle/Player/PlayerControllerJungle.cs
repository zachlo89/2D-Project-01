using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerJungle : MonoBehaviour
{
    // no rigidbody
    private Animator _anim;
    private CharacterController _charController;
    private Camera _cam;

    private Vector3 _direction;
    private Vector3 _velocity;
    private bool _jumping = false;

    private float _minClampVal = 0.0f;
    private float _maxClampVal = 35.0f;

    [Header("Controller Settings")]
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _gravity;
    [SerializeField] private float _speed;

    [Header("Cam Settings")]
    [SerializeField] private float _camSensitivity;


    // see what mouseX and Y returning
    //public float mouseX;


    void Start()
    {
        _charController = GetComponent<CharacterController>();
        if (_charController == null)
        {
            Debug.LogError("Char Controller is NULL");
        }
        
        // grabs cam that's tagged main cam
        _cam = Camera.main;
        if (_cam == null)
        {
            Debug.LogError("Main Cam is NULL");
        }

        _anim = GetComponentInChildren<Animator>();
        if (_anim == null)
        {
            Debug.LogError("Animator is NULL");
        }
    }


    void FixedUpdate()
    {
        CalcCharacterMovement();
        CalcCamMovement();

        /*
         * local to world space conversion; tk dir tform from local to worldspc
         * TransformDirection; chk velocity below in char move script
        */
    }

    void CalcCharacterMovement()
    {
        if (_charController.isGrounded == true)
        {
            if (_jumping == true)
            {
                _jumping = false;
                _anim.SetBool("Jump", _jumping);
            }

            float _horizMove = Input.GetAxisRaw("Horizontal");
            float _vertMove = Input.GetAxisRaw("Vertical");

            _direction = new Vector3(_horizMove, 0, _vertMove);
            _anim.SetFloat("Speed", Mathf.Abs(_vertMove));

            // if dir on 
            _velocity = _direction * _speed;


            if (Input.GetKeyDown(KeyCode.Space))
            {
                _velocity.y = _jumpHeight;
                _jumping = true;
                _anim.SetBool("Jump", _jumping);
            }
        }

        // tk velocity from localspc to worldspc
        // allows to travel or move in dir facing with cam
        _velocity = transform.TransformDirection(_velocity);

        // this always called; gravity always working
        _velocity.y -= _gravity * Time.deltaTime;

        // Move controller - dir of input
        _charController.Move(_velocity * Time.deltaTime);
    }

    void CalcCamMovement()
    {
        //mouseX = Input.GetAxisRaw("Mouse X");
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        /*
         * LOOK L+R
         * mouseX is player rot; nn apply to Y axis
         * transform.localEulerAngles = new Vector3(transform.eulerAngles.x, transform.localEulerAngles.y + mouseX, transform.localEulerAngles.z);
         * locking gimble fix
        */
        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.y += mouseX * _camSensitivity;
        transform.localEulerAngles = currentRotation;
        transform.localRotation = Quaternion.AngleAxis(currentRotation.y, Vector3.up);


        /*
         * LOOK UP+DOWN
         * mouseY is cam vert; nn apply to X axis Up + Down; nn clamp so no over rot 12 and -5
         * nn a ref to cam
         * locking gimble fix
        */
        Vector3 currentCamRotation = _cam.transform.localEulerAngles;
        currentCamRotation.x -= mouseY * _camSensitivity;
        currentCamRotation.x = Mathf.Clamp(currentCamRotation.x, _minClampVal, _maxClampVal);
        // specify angle to chng by degrees pass into angleaxis; rot around axis
        _cam.transform.localEulerAngles = currentCamRotation;
        _cam.transform.localRotation = Quaternion.AngleAxis(currentCamRotation.x, Vector3.right);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }

}