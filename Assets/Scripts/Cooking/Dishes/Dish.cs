using System.Collections.Generic;
using UnityEngine;

namespace Cooking.Dishes
{
    [CreateAssetMenu(fileName = "New Dish", menuName = "Cooking/Dish")]
    public class Dish : ScriptableObject
    {
        public List<IngredientType> ingredients;
    }
}