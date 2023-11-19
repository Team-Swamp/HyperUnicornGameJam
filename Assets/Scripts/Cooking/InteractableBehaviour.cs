using UnityEngine;
using Cooking.Ingredients;

namespace Cooking
{
    public class InteractableBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject hoverObject;
        private GameObject _hoverObjectInstance;
        [SerializeField] private Ingredient ingredient;
        [SerializeField] private float distance;
        
        private Transform WorldCanvas => GameObject.Find("WorldCanvas").transform;
        private Transform Player => GameObject.Find("PlayerObject").transform;
        private CookingBehaviour Cooking => Player.GetComponent<CookingBehaviour>();
        
        void Start()
        {
            _hoverObjectInstance = Instantiate(hoverObject, transform.position, Quaternion.identity, WorldCanvas);
            _hoverObjectInstance.transform.localScale = transform.localScale * 2;
            _hoverObjectInstance.SetActive(false);
        }

        void Update()
        {
            if (_hoverObjectInstance.activeInHierarchy && Input.GetKeyDown(KeyCode.E))
            {
                Cooking.CollectIngredient(ingredient);
            }
            //Debug.Log(_hoverObjectInstance.activeSelf + " " + _hoverObjectInstance.activeInHierarchy);
        }

        void OnMouseEnter()
        {
            if ((transform.position - Player.position).magnitude < distance) 
                _hoverObjectInstance.SetActive(true);
            Debug.Log("Test if it hovers");
        }

        void OnMouseExit() => _hoverObjectInstance.SetActive(false);
    }
}