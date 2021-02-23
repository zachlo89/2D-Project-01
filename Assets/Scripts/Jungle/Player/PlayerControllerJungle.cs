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
    }


    void Update()
    {
        CalcCharacterMovement();

        // x mouse
        //mouseX = Input.GetAxisRaw("Mouse X");
        float mouseX = Input.GetAxisRaw("Mouse X");
        // y mouse
        float mouseY = Input.GetAxisRaw("Mouse Y");
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