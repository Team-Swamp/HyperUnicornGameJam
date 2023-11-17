using UnityEngine;

namespace Cooking.Ingredients
{
    [CreateAssetMenu(fileName = "New Ingredient", menuName = "Cooking/Ingredient")]
    public class Ingredient : ScriptableObject
    {
         public int points;
         public IngredientType type;
    }

}
