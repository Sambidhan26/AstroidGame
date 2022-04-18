using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField]
    private ScoreScript scoreScript;

    [SerializeField]
    private Text gameOverText;
    [SerializeField]
    private GameObject gameOverScene;
    [SerializeField]
    private AsteroidSpawner asteroidSpawner;


    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void EndGame()
    {
        int finalScore = scoreScript.EndTimer();

        gameOverText.text = $"Your Score: {finalScore}";
        asteroidSpawner.enabled = false;

        gameOverScene.SetActive(true);
    }


    
}
