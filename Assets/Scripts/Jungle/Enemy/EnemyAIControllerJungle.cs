using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIControllerJungle : MonoBehaviour
{
    private CharacterController _charController;
    private Transform _player;
    //[SerializeField] private PlayerControllerJungle _playerControllerJungle;

    private Vector3 _velocity;

    [SerializeField] private float _speed;
    [SerializeField] private float _gravity;


    void Start()
    {
        _charController = GetComponent<CharacterController>();
        if (_charController == null)
        {
            Debug.LogError("Char Controller is NULL");
        }

        //_playerControllerJungle = GetComponent<PlayerControllerJungle>();
        //if (_playerControllerJungle == null)
        //{
        //    Debug.LogError("Player Controller is NULL");
        //}
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // chk if grounded
        // if yes then move
        // calc dir
        // cal velocity

        // if not grounded subtract gravity 
        // move to player (velocity)

        if (_charController.isGrounded == true)
        {
            Vector3 direction = _player.transform.position - transform.position;
            // makes vector magnitude 1 normalize vector
            direction.Normalize();
            // if grounded dir.y is 0; fix funky rotation
            direction.y = 0;
            // rot toward player
            transform.localRotation = Quaternion.LookRotation(direction);
            _velocity = direction * _speed;
        }

        //_velocity = transform.TransformDirection(_velocity);

        _velocity.y -= _gravity * Time.deltaTime;

        _charController.Move(_velocity * Time.deltaTime);
    }
}