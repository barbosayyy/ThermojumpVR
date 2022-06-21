using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickup : MonoBehaviour
{
    public int score;
    public TMPro.TextMeshProUGUI scoreText;

    public void Score()
    {
        score++;
        SetScoreText();
    }

    private void SetScoreText()
    {
        scoreText.text = score + "/3";
    }
}
