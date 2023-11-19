using System;
using UnityEngine;
using TMPro;

public class PointSystem : MonoBehaviour
{
    private int score;

    [SerializeField] private int multiplier;
    private TMP_Text PointsText => GameObject.Find("PointText").GetComponent<TMP_Text>();

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

    private void SetScoreText() => PointsText.text = score.ToString();
}