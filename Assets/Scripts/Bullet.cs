using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    void Start()
    {
        Destroy(this.gameObject, 3.0f);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * 10 * Time.deltaTime);
    }
}
