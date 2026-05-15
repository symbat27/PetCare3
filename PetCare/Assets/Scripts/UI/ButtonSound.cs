using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioClip buttonClip;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonClip);
    }
}
