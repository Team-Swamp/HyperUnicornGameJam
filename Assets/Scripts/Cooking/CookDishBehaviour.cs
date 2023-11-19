using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CookDishBehaviour : MonoBehaviour
{
    public UnityEvent Cook;

    [SerializeField] private GameObject hoverObject;
    [SerializeField] private float distance;
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
            Cook.Invoke();
        }
    }

    void OnMouseEnter()
    {
        if ((transform.position - Player.position).magnitude < distance)
            _hoverObjectInstance.SetActive(true);
    }

    void OnMouseExit() => _hoverObjectInstance.SetActive(false);
}
