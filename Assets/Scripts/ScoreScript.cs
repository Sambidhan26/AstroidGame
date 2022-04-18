 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{

    [SerializeField]
    private TMP_Text scoreText;

    [SerializeField]
    private float scoreMultiplier;
    private float score;

    private bool shouldCount;
    // Update is called once per frame
    void Update()
    {
        if (shouldCount)
        {
            return;
        }

        score += Time.deltaTime * scoreMultiplier;

        scoreText.text = Mathf.FloorToInt(score).ToString();

        //scoreText.text = "Hello";
    }

    public int EndTimer()
    {
        shouldCount = true;

        scoreText.text = string.Empty;

        return Mathf.FloorToInt(score);
    }
}
