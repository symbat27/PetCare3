using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public AudioSource buttonClickSound;

    public void LoadPetRoom()
    {
        PlayClick();
        SceneManager.LoadScene("PetRoom_Level1");
    }

    public void LoadSettings()
    {
        PlayClick();
        SceneManager.LoadScene("Settings");
    }

    public void QuitGame()
    {
        PlayClick();
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