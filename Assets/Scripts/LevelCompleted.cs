using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleted : MonoBehaviour
{
    [SerializeField] private GameObject winningPanel;
    [SerializeField] private ScoreCounter scoreCounter;
    public void Win()
    {
        winningPanel.SetActive(true);
        scoreCounter.StopCouting();
    }
}
