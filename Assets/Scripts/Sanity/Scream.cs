using UnityEngine;

public class Scream : MonoBehaviour
{
    [SerializeField] private int maxSanity;
    [SerializeField] private int currentSanity;

    [SerializeField] private SanitySystem sanitySystem;

    private void Start()
    {
        currentSanity = maxSanity;
        sanitySystem.SetMaxSanity(maxSanity);
    }

    private void Update() => UpdateSanity();

    private void LowerSanity(int lower)
    {
        currentSanity -= lower;
        sanitySystem.SetSanity(currentSanity);
    }

    private void UpdateSanity()
    {
        if (Input.GetKeyDown(KeyCode.F)) LowerSanity(20);
    }
}