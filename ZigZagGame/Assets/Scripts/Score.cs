using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float score;
    private float increaseAmount = 1.25f;

    private void FixedUpdate()
    {
        score += (increaseAmount * Time.deltaTime);
    }
}
