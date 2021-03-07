using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuStartGame : MonoBehaviour
{
    public void TransitToGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
