using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PetManager : MonoBehaviour
{
    public Slider hungerSlider;
    public Slider happinessSlider;
    public Slider cleanlinessSlider;

    public TMP_Text scoreText;

    public SpriteRenderer petRenderer;

    public Sprite normalSprite;
    public Sprite hungrySprite;
    public Sprite dirtySprite;

    private float hunger = 100f;
    private float happiness = 100f;
    private float cleanliness = 100f;

    private int score = 0;

    void Start()
    {
        SetupSlider(hungerSlider);
        SetupSlider(happinessSlider);
        SetupSlider(cleanlinessSlider);

        UpdateUI();
        UpdatePetEmotion();
    }

    void Update()
    {
        hunger -= Time.deltaTime * 2.5f;
        cleanliness -= Time.deltaTime * 1.5f;
        happiness -= Time.deltaTime * 0.8f;

        hunger = Mathf.Clamp(hunger, 0, 100);
        cleanliness = Mathf.Clamp(cleanliness, 0, 100);
        happiness = Mathf.Clamp(happiness, 0, 100);

        UpdateUI();
        UpdatePetEmotion();
    }

    public void FeedPet()
    {
        hunger = Mathf.Clamp(hunger + 30f, 0, 100);
        score += 10;
        UpdateUI();
        UpdatePetEmotion();
    }

    public void CleanPet()
    {
        cleanliness = Mathf.Clamp(cleanliness + 30f, 0, 100);
        score += 10;
        UpdateUI();
        UpdatePetEmotion();
    }

    public void PlayMiniGame()
    {
        SceneManager.LoadScene("Garden_Level2");
    }

    private void SetupSlider(Slider slider)
    {
        slider.minValue = 0;
        slider.maxValue = 100;
        slider.interactable = false;
    }

    private void UpdateUI()
    {
        hungerSlider.value = hunger;
        happinessSlider.value = happiness;
        cleanlinessSlider.value = cleanliness;

        scoreText.text = "Score: " + score;
    }

    private void UpdatePetEmotion()
    {
        if (hunger < 50)
        {
            petRenderer.sprite = hungrySprite;
        }
        else if (cleanliness < 50)
        {
            petRenderer.sprite = dirtySprite;
        }
        else
        {
            petRenderer.sprite = normalSprite;
        }
    }
}