using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private SimpleObjectPool pool;
    [SerializeField] private List<Transform> spawnignPositions = new List<Transform>();
    [SerializeField] private moveDirection moveDirection;
    [SerializeField, Range(.5f, 5f)] private float spawningSpeed;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", spawningSpeed, spawningSpeed);
    }

    private void SpawnEnemy()
    {
        for(int i = 0; i < spawnignPositions.Count; i++)
        {
            GameObject temp = pool.ReturnObject();
            temp.transform.position = spawnignPositions[i].position;
            temp.GetComponent<EnemyScript>().ChangeDirection(moveDirection.forward);
            temp.SetActive(true);
            switch (moveDirection)
            {
                case moveDirection.forward:
                    temp.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    break;
                case moveDirection.back:
                    temp.transform.localRotation = Quaternion.Euler(0, 180, 0);
                    break;
                case moveDirection.left:
                    temp.transform.localRotation = Quaternion.Euler(0, -90, 0);
                    break;
                case moveDirection.right:
                    temp.transform.localRotation = Quaternion.Euler(0, 90, 0);
                    break;
                default:
                    temp.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    break;
            }

        }
    }



}
