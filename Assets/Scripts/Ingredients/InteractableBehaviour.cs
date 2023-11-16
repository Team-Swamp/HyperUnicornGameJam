using UnityEngine;

namespace Ingredients
{
    public class InteractableBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject hoverObject;
        private GameObject _hoverObjectInstance;
        private Transform WorldCanvas => GameObject.Find("WorldCanvas").transform;
        private Transform Player => GameObject.Find("PlayerObject").transform;

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
                // NOTE: add interaction
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