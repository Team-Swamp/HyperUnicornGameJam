using UnityEngine;

public class SanitySystem : MonoBehaviour
{
    [SerializeField] private int maxSanity;
    [SerializeField] private int currentSanity;

    [SerializeField] private SanityBarController sanityBarController;

    private void Start()
    {
        currentSanity = maxSanity;
        sanityBarController.SetMaxSanity(maxSanity);
    }

    private void Update() => UpdateSanity();

    private void LowerSanity(int lower)
    {
        currentSanity -= lower;
        sanityBarController.SetSanity(currentSanity);
    }

    private void UpdateSanity()
    {
        if (Input.GetKeyDown(KeyCode.F)) LowerSanity(20);
    }
}