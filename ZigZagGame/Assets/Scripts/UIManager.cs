using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    private Score score;

    private void Awake()
    {
        score = FindObjectOfType<Score>();
    }

    private void Update()
    {
        scoreText.text = "Score: " + ((int)score.score).ToString();
    }
}
