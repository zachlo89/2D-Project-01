using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerJungle : MonoBehaviour
{
    // no rigid body
    private CharacterController _charController;

    private Vector3 _direction;
    private Vector3 _velocity;

    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _gravity;
    [SerializeField] private float _speed;

    // see what mouseX and Y returning
    //public float mouseX;


    void Start()
    {
        _charController = GetComponent<CharacterController>();
        if (_charController == null)
        {
            Debug.LogError("Char Controller is NULL");
        }

        //_playerJungle = GetComponent<PlayerControllerJungle>();
        //if (_playerJungle == null)
        //{
        //    Debug.LogError("Player Jungle is NULL");
        //}

        //_mainCam = GetComponent<Camera>();
        //if (_mainCam == null)
        //{
        //    Debug.LogError("Main Cam is NULL");
        //}
    }


    void Update()
    {
        // x mouse
        //mouseX = Input.GetAxisRaw("Mouse X");
        float mouseX = Input.GetAxisRaw("Mouse X");
        // y mouse
        float mouseY = Input.GetAxisRaw("Mouse Y");

        // mouseX is player rot; nn apply to Y axis looking L+R
        transform.localEulerAngles = new Vector3(transform.eulerAngles.x, transform.localEulerAngles.y + mouseX, transform.localEulerAngles.z);

        // mouseY is cam vert; nn apply to X axis Up + Down; nn clamp so no over rot 12 and -5


        CalcCharacterMovement();
    }

    void CalcCharacterMovement()
    {
        if (_charController.isGrounded == true)
        {
            float _horizMove = Input.GetAxisRaw("Horizontal");
            float _vertMove = Input.GetAxisRaw("Vertical");

            _direction = new Vector3(_horizMove, 0, _vertMove);
            _velocity = _direction * _speed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _velocity.y = _jumpHeight;
            }
        }

        // this always called; gravity always working
        _velocity.y -= _gravity * Time.deltaTime;

        // Move controller - dir of input
        _charController.Move(_velocity * Time.deltaTime);
    }
}