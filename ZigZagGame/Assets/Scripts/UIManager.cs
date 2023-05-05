using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private Text scoreText, bestScoreText;

    [Header("Panels")]
    [SerializeField] private GameObject restartPanel, startPanel;

    [Header("Other Scripts")]
    private Score scoreCs;

    private void Awake()
    {
        scoreCs = FindObjectOfType<Score>();
    }

    private void Start()
    {
        bestScoreText.text = (int)PlayerPrefs.GetFloat("BestScore")+"";
    }

    private void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + ((int)scoreCs.score);

        if (PlayerPrefs.GetFloat("BestScore") < scoreCs.score)
        {
            bestScoreText.text = "Best Score: " + ((int)scoreCs.score);
        }
    }

    public void PlayPanel(bool isActive)
    {
        startPanel.SetActive(isActive);
    }

    public void RestartPanel(bool isActive)
    {
        restartPanel.SetActive(isActive);
    }
}
