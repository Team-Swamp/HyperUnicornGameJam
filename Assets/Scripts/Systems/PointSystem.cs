using System;
using UnityEngine;
using TMPro;

public class PointSystem : MonoBehaviour
{
    private int score;

    [SerializeField] private int multiplier;
    [SerializeField] private TMP_Text pointsText;

    private void Start() => SetScoreText();

    public void AddPoint(int amount)
    {
        score += amount * multiplier;
        
        SetScoreText();
    }

    public void ResetScore()
    {
        score = 0;
        
        SetScoreText();
    }

    private void SetScoreText() => pointsText.text = score.ToString();
}