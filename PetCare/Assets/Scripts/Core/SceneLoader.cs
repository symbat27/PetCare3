using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public AudioSource buttonClickSound;

    public void LoadPetRoom()
    {
        PlayClick();
        Invoke(nameof(OpenPetRoom), 0.15f);
    }

    public void LoadSettings()
    {
        PlayClick();
        Invoke(nameof(OpenSettings), 0.15f);
    }

    public void QuitGame()
    {
        PlayClick();
        Invoke(nameof(QuitApplication), 0.15f);
    }

    private void OpenPetRoom()
    {
        SceneManager.LoadScene("PetRoom_Level1");
    }

    private void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    private void QuitApplication()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    private void PlayClick()
    {
        if (buttonClickSound != null)
        {
            buttonClickSound.Play();
        }
    }
}