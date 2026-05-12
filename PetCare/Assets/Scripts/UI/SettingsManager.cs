using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle shadowsToggle;

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);

        bool shadows = PlayerPrefs.GetInt("Shadows", 1) == 1;
        shadowsToggle.isOn = shadows;

        AudioListener.volume = volumeSlider.value;

        QualitySettings.shadows = shadows
            ? ShadowQuality.All
            : ShadowQuality.Disable;
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;

        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }

    public void ToggleShadows()
    {
        if (shadowsToggle.isOn)
        {
            QualitySettings.shadows = ShadowQuality.All;
            PlayerPrefs.SetInt("Shadows", 1);
        }
        else
        {
            QualitySettings.shadows = ShadowQuality.Disable;
            PlayerPrefs.SetInt("Shadows", 0);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main");
    }
}

