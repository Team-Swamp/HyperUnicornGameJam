using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointSystem : MonoBehaviour
{
    private int score;

    [SerializeField] private int multiplier;
    
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

    private void SetScoreText()
    {
        GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}