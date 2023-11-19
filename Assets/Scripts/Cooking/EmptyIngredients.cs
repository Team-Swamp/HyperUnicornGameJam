using System.Collections;
using System.Collections.Generic;
using Cooking;
using Cooking.Dishes;
using UnityEngine;

public class EmptyIngredients : MonoBehaviour
{

    [SerializeField] private GameObject hoverObject;
    [SerializeField] private float distance;
    [SerializeField] private CookingBehaviour cookingBehaviour;
    private GameObject _hoverObjectInstance;

    private Transform WorldCanvas => GameObject.Find("WorldCanvas").transform;
    private Transform Player => GameObject.Find("PlayerObject").transform;

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
            cookingBehaviour.collectedIngredients.Clear();
        }
    }

    void OnMouseEnter()
    {
        if ((transform.position - Player.position).magnitude < distance)
            _hoverObjectInstance.SetActive(true);
    }

    void OnMouseExit() => _hoverObjectInstance.SetActive(false);
}
