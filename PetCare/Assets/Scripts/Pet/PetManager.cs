using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class PetManager : MonoBehaviour
{
    public Slider hungerSlider;
    public Slider happinessSlider;
    public Slider cleanlinessSlider;

    public Image hungerFill;
    public Image happinessFill;
    public Image cleanlinessFill;

    public Image ageCircleFill;
    public TMP_Text ageText;

    public TMP_Text scoreText;
    public SpriteRenderer petRenderer;

    public Sprite normalSprite;
    public Sprite hungrySprite;
    public Sprite dirtySprite;
    public Sprite happySprite;
    public Sprite playSprite;

    public Vector3 petFixedPosition = new Vector3(-1.3f, -2.2f, 0f);

    private float hunger = 100f;
    private float happiness = 100f;
    private float cleanliness = 100f;

    private int score = 0;
    private int age = 1;
    private float ageProgress = 0f;
    private float maxAgeProgress = 100f;

    private bool showingTemporaryEmotion = false;

    void Start()
    {
        SetupSlider(hungerSlider);
        SetupSlider(happinessSlider);
        SetupSlider(cleanlinessSlider);

        FixPetTransform();
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

        FixPetTransform();
        UpdateUI();

        if (!showingTemporaryEmotion)
        {
            UpdatePetEmotion();
        }
    }

    public void FeedPet()
    {
        hunger = Mathf.Clamp(hunger + 35f, 0, 100);
        happiness = Mathf.Clamp(happiness + 5f, 0, 100);
        score += 10;
        AddAgeProgress(10f);

        StartCoroutine(ShowEmotionForSeconds(happySprite));
    }

    public void CleanPet()
    {
        cleanliness = Mathf.Clamp(cleanliness + 35f, 0, 100);
        happiness = Mathf.Clamp(happiness + 5f, 0, 100);
        score += 10;
        AddAgeProgress(10f);

        StartCoroutine(ShowEmotionForSeconds(happySprite));
    }

    public void PlayMiniGame()
    {
        StartCoroutine(ShowPlayThenLoad());
    }

    private IEnumerator ShowPlayThenLoad()
    {
        showingTemporaryEmotion = true;

        petRenderer.sprite = playSprite;
        petRenderer.transform.localScale = new Vector3(0.4f, 0.4f, 1f);

        yield return new WaitForSeconds(0.7f);

        SceneManager.LoadScene("Garden_Level2");
    }

    private void SetupSlider(Slider slider)
    {
        slider.minValue = 0;
        slider.maxValue = 100;
        slider.interactable = false;
    }

    private void FixPetTransform()
    {
        petRenderer.transform.position = petFixedPosition;
        petRenderer.sortingOrder = 10;
    }

    private void UpdateUI()
    {
        hungerSlider.value = hunger;
        happinessSlider.value = happiness;
        cleanlinessSlider.value = cleanliness;

        hungerFill.color = GetSliderColor(hunger);
        happinessFill.color = GetSliderColor(happiness);
        cleanlinessFill.color = GetSliderColor(cleanliness);

        scoreText.text = "Score: " + score;

        ageCircleFill.fillAmount = ageProgress / maxAgeProgress;
        ageText.text = "Age " + age;
    }

    private void AddAgeProgress(float amount)
    {
        ageProgress += amount;

        if (ageProgress >= maxAgeProgress)
        {
            age++;
            ageProgress = 0f;
        }

        UpdateUI();
    }

    private Color GetSliderColor(float value)
    {
        if (value > 70)
        {
            return Color.green;
        }
        else if (value > 50)
        {
            return Color.yellow;
        }
        else
        {
            return Color.red;
        }
    }

    private void UpdatePetEmotion()
    {
        if (hunger < 50)
        {
            petRenderer.sprite = hungrySprite;
            petRenderer.transform.localScale = new Vector3(0.4f, 0.4f, 1f);
        }
        else if (cleanliness < 50)
        {
            petRenderer.sprite = dirtySprite;
            petRenderer.transform.localScale = new Vector3(0.4f, 0.4f, 1f);
        }
        else
        {
            petRenderer.sprite = normalSprite;
            petRenderer.transform.localScale = new Vector3(0.48f, 0.48f, 1f);
        }
    }

    private IEnumerator ShowEmotionForSeconds(Sprite emotionSprite)
    {
        showingTemporaryEmotion = true;

        petRenderer.sprite = emotionSprite;
        petRenderer.transform.localScale = new Vector3(0.48f, 0.48f, 1f);

        yield return new WaitForSeconds(1f);

        showingTemporaryEmotion = false;
        UpdatePetEmotion();
    }
}
