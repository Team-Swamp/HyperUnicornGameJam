using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableBehaviour : MonoBehaviour
{
    [SerializeField] GameObject hoverObject;
    Transform worldCanvas => GameObject.Find("WorldCanvas").transform;
    [SerializeField] Transform player;
    GameObject hoverObjectInstance;

    // Start is called before the first frame update
    void Start()
    {
        hoverObjectInstance = Instantiate(hoverObject, transform.position, Quaternion.identity, worldCanvas);
        hoverObjectInstance.transform.localScale = transform.localScale * 2;
        hoverObjectInstance.SetActive(false);
    }

    void Update()
    {
        if (hoverObjectInstance.activeInHierarchy && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Collected");
        }
    }

    void OnMouseEnter()
    {
        if ((transform.position - player.position).magnitude < 2)
        {
            hoverObjectInstance.SetActive(true);
        }
    }
    void OnMouseExit()
    {
        hoverObjectInstance.SetActive(false);
    }
}
