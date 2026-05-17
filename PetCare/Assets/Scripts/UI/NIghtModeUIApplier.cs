using UnityEngine;
using UnityEngine.UI;

public class NightModeUIApplier : MonoBehaviour
{
    public GameObject nightOverlay;

    public Image backgroundImage;
    public Sprite dayBackground;
    public Sprite nightBackground;

    void Start()
    {
        ApplyNightMode();
    }

    public void ApplyNightMode()
    {
        bool nightMode = PlayerPrefs.GetInt("NightMode", 0) == 1;

        nightOverlay.SetActive(nightMode);

        if (nightMode)
        {
            backgroundImage.sprite = nightBackground;
        }
        else
        {
            backgroundImage.sprite = dayBackground;
        }
    }
}
