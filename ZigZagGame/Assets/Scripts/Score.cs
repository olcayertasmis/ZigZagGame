using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [Header("Score Variables")]
    public float score;
    private float _increaseAmount = 1.25f;

    private void Update()
    {
        score += (_increaseAmount * Time.deltaTime);

        UpdateBestScore();
    }

    private void UpdateBestScore()
    {
        if(PlayerPrefs.GetFloat("BestScore") < (int)score) PlayerPrefs.SetFloat("BestScore", score);

    }
}
