using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulu : MonoBehaviour
{
    [SerializeField, Range (0, 360)] private float angle = 90f;
    [SerializeField, Range (0, 5)] private float speed = 2f;
    [SerializeField, Range(0, 10)] private float startTime = 0;
    private Quaternion start, end;

    void Start()
    {
        start = PendulumRotation(angle);
        end = PendulumRotation(-angle);
    }

    private void FixedUpdate()
    {
        startTime += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(start, end, (Mathf.Sin(startTime*speed + Mathf.PI / 2) + 1f) /2f);
    }

    private Quaternion PendulumRotation(float angle)
    {
        Quaternion pendulumRotation = transform.rotation;
        var angleZ = pendulumRotation.eulerAngles.z + angle;

        if(angleZ > 180)
        {
            angleZ -= 360;
        } else if(angleZ < -180)
        {
            angleZ += 360;
        }

        pendulumRotation.eulerAngles = new Vector3(pendulumRotation.eulerAngles.x, pendulumRotation.eulerAngles.y, angleZ);
        return pendulumRotation;
    }

    private void ResetTimer()
    {
        startTime = 0f;
    }
}
