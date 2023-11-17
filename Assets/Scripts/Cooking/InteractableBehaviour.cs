using UnityEngine;

namespace Cooking
{
    public class InteractableBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject hoverObject;
        private GameObject _hoverObjectInstance;
        [SerializeField] private IngredientType type;
        
        private Transform WorldCanvas => GameObject.Find("WorldCanvas").transform;
        private Transform Player => GameObject.Find("PlayerObject").transform;
        private CookingBehaviour Cooking => Player.GetComponent<CookingBehaviour>();

        // Start is called before the first frame update
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
                Cooking.CollectIngredient(type);
            }
        }

        void OnMouseEnter()
        {
            if ((transform.position - Player.position).magnitude < 2) 
                _hoverObjectInstance.SetActive(true);
        }

        void OnMouseExit() => _hoverObjectInstance.SetActive(false);
    }
}