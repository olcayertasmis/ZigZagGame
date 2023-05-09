using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [Header("Score Variables")]
    public float score;
    private float _increaseAmount = 1.25f;

    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (!playerController.isStart) return;

        score += (_increaseAmount * Time.deltaTime);

        UpdateBestScore();
    }

    private void UpdateBestScore()
    {
        if (PlayerPrefs.GetFloat("BestScore") < (int)score) PlayerPrefs.SetFloat("BestScore", score);
    }

    public void IncreaseScore(float amount)
    {
        score += amount;
    }
}