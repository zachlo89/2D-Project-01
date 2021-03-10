using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPlayer : MonoBehaviour
{
    private Transform playerParent;
    public Transform player = null;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            playerParent = collision.gameObject.transform.parent;
            player = collision.gameObject.transform;
            player.SetParent(transform.parent);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            player.SetParent(playerParent);
            player = null;
        }
    }

}
