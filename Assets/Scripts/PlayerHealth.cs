using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private GameOverHandler gameOver;
    public void Crash()
    {
        gameOver.EndGame();
        gameObject.SetActive(false);
    }
}
