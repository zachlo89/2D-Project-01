using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePlayer : MonoBehaviour
{
    [SerializeField] private Transform objectToFollow;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 firstPerson;
    [SerializeField] private Vector3 thirdPerson;
    private bool changeRotation = true;
    [SerializeField, Range(1, 3)] private int cameraSettings;

    private void Update()
    {
        switch (cameraSettings)
        {
            case 1:
                Camera1Settings();
                break;
            case 2:
                Camera2Settings();
                break;
            case 3:
                Camera3Settings();
                break;
            default:
                Camera1Settings();
                break;
        }
    }

    private void Camera1Settings()
    {
        transform.localRotation = Quaternion.Euler(35, -20, 0);
        transform.position = objectToFollow.transform.position + offset;
    }

    private void Camera2Settings()
    {
        transform.position = objectToFollow.position + thirdPerson;
        transform.localRotation = Quaternion.Euler(20, 0, 0);
    }

    private void Camera3Settings()
    {
        transform.localRotation = Quaternion.Euler(18, 0, 0);
        transform.position = objectToFollow.position + firstPerson;
    }

}
