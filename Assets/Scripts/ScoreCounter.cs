using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private ScriptableFloat score;
    [SerializeField] private Text scoreHolder;
    private bool coutingScore = true;

    private void Update()
    {
        if (coutingScore)
        {
            score.value = (player.transform.position.z - 27) / 10;
            scoreHolder.text = ((int)score.value).ToString();
        }
    }

    public void StopCouting()
    {
        coutingScore = false;
    }
}
