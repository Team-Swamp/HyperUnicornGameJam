using UnityEngine;
using UnityEngine.UI;

public class SanityBarController : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void SetMaxSanity(int sanity)
    {
        slider.maxValue = sanity;
        slider.value = sanity;
    }

    public void SetSanity(int sanity)
    {
        slider.value = sanity;
    }
}
