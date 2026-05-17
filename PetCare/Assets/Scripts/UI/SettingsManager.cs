using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle nightModeToggle;

    public GameObject saveText;

    public TextMeshProUGUI modeText;

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        AudioListener.volume = volumeSlider.value;

        bool nightMode = PlayerPrefs.GetInt("NightMode", 0) == 1;
        nightModeToggle.isOn = nightMode;

        UpdateModeText();

        saveText.SetActive(false);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);

        if (nightModeToggle.isOn)
        {
            PlayerPrefs.SetInt("NightMode", 1);
        }
        else
        {
            PlayerPrefs.SetInt("NightMode", 0);
        }

        AudioListener.volume = volumeSlider.value;

        UpdateModeText();

        ShowSaveText();
    }

    void UpdateModeText()
    {
        if (nightModeToggle.isOn)
        {
            modeText.text = "Night Mode";
        }
        else
        {
            modeText.text = "Day Mode";
        }
    }

    void ShowSaveText()
    {
        saveText.SetActive(true);

        CancelInvoke(nameof(HideSaveText));

        Invoke(nameof(HideSaveText), 1.5f);
    }

    void HideSaveText()
    {
        saveText.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnNightToggleChanged()
    {
        UpdateModeText();
    }
}