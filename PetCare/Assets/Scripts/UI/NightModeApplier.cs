using UnityEngine;

public class NightModeApplier : MonoBehaviour
{
    public GameObject nightOverlay;

    public SpriteRenderer backgroundRenderer;

    public Sprite dayBackground;
    public Sprite nightBackground;

    void Start()
    {
        bool nightMode = PlayerPrefs.GetInt("NightMode", 0) == 1;

        nightOverlay.SetActive(nightMode);

        if (nightMode)
        {
            backgroundRenderer.sprite = nightBackground;
        }
        else
        {
            backgroundRenderer.sprite = dayBackground;
        }
    }
}
