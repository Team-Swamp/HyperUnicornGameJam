using System;
using System.Collections;
using System.Collections.Generic;
using Cooking;
using Cooking.Dishes;
using UnityEngine;

public class CobineToDish : MonoBehaviour
{
    [SerializeField] private Dish dish;
    [SerializeField] private CookingBehaviour cookingBehaviour;

    private void Update()
    {
        CompareDish();
    }

    private void CompareDish()
    {
        if (dish.ingredients.Count == cookingBehaviour.collectedIngredients.Count)
        {
            Debug.Log("test");
        }
    }
}
