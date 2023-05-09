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

    private Animator restartPanelAnim, startPanelAnim, bestScoreTextAnim;

    private void Awake()
    {
        scoreCs = FindObjectOfType<Score>();
        restartPanelAnim = restartPanel.GetComponent<Animator>();
        startPanelAnim = startPanel.GetComponent<Animator>();
        bestScoreTextAnim = bestScoreText.GetComponent<Animator>();
    }

    private void Start()
    {
        bestScoreText.text = "Best Score: " + (int)PlayerPrefs.GetFloat("BestScore");
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
            bestScoreTextAnim.SetTrigger("NewBestScore");
            bestScoreText.text = "Best Score: " + ((int)scoreCs.score);
        }
    }

    public void PlayPanel(bool isActive)
    {
        if (isActive) startPanelAnim.Play("OpenStartPanel");
        startPanel.SetActive(isActive);
    }

    public void RestartPanel(bool isActive)
    {
        if (isActive) restartPanelAnim.Play("OpenRestartPanel");
        restartPanel.SetActive(isActive);
    }
}