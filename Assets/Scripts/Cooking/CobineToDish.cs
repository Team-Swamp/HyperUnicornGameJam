using System;
using System.Collections;
using System.Collections.Generic;
using Cooking;
using Cooking.Dishes;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class CobineToDish : MonoBehaviour
{
    [SerializeField] private Dish dish;
    [SerializeField] private CookingBehaviour cookingBehaviour;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.SetText("Score: 0");
    }

    public void CompareDish()
    { 
        if (dish.ingredients.Count == cookingBehaviour.collectedIngredients.Count)
        {
            TotalScore.totalScore += dish.scoreAmount;
            Debug.Log("Score: " + TotalScore.totalScore);
            scoreText.SetText("Score: " + TotalScore.totalScore.ToString());
        }

        cookingBehaviour.collectedIngredients.Clear();
    }
}
