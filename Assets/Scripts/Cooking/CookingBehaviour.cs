using System.Collections.Generic;
using System.Linq;
using Cooking.Dishes;
using Cooking.Ingredients;
using UnityEngine;

namespace Cooking
{
    public class CookingBehaviour : MonoBehaviour
    {
        [SerializeField] private Dish currentDish;
        public List<Ingredient> collectedIngredients = new List<Ingredient>();
        private PointSystem PointSystem => GameObject.Find("PointSystem").GetComponent<PointSystem>();

        public void CollectIngredient(Ingredient ingredient)
        {
            collectedIngredients.Add(ingredient);
            CheckIngredients();
        }

        private void CheckIngredients()
        {
            if (currentDish.ingredients.Count != collectedIngredients.Count) return;
            
            List<bool> check = new List<bool>();
            for (int i = 0; i < collectedIngredients.Count; i++)
            {
                check.Add(currentDish.ingredients[i] == collectedIngredients[i].type);
            }

            if (!check.All(i => i)) return;

            foreach (var ingredient in collectedIngredients)
            {
                PointSystem.AddPoint(ingredient.points);
            }
        }
    }
}