using System.Collections.Generic;
using System.Linq;
using Cooking.Dishes;
using UnityEngine;

namespace Cooking
{
    public class MergingBehaviour : MonoBehaviour
    {
        [SerializeField] private Dish currentDish;
        private List<IngredientType> _collectedIngredients = new List<IngredientType>();

        public void CollectIngredient(IngredientType type)
        {
            _collectedIngredients.Add(type);
            CheckIngredients();
        }

        private void CheckIngredients()
        {
            if (currentDish.ingredients.Count != _collectedIngredients.Count)
            {
                return;
            }
            
            List<bool> check = new List<bool>();
            for (int i = 0; i < _collectedIngredients.Count; i++)
            {
                check.Add(currentDish.ingredients[i] == _collectedIngredients[i]);
            }

            if (check.All(i => i))
            {
                Debug.Log("Collect points!");
            }
        }
    }
}