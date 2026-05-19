using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayWithFriendManager : MonoBehaviour
{
    public Transform friendDog;
    public Animator friendAnimator;

    public SpriteRenderer mainPetRenderer;
    public Sprite mainPetPlaySprite;

    public AudioSource calmMusicAudio;
    public AudioSource dogBarkAudio;
    public AudioSource buttonClickAudio;

    public float moveSpeed = 2.2f;
    public float waitAtPoint = 0.25f;

    public Vector3 mainPetPlayScale = new Vector3(0.14f, 0.14f, 1f);
    public Vector3 friendDogScale = new Vector3(3.2f, 3.2f, 1f);

    private Vector3[] playPositions =
    {
        new Vector3(-1.8f, -2.9f, 0f),
        new Vector3(0.8f, -2.2f, 0f),
        new Vector3(1.5f, -2.8f, 0f),
        new Vector3(-0.4f, -2.4f, 0f),
        new Vector3(-1.5f, -2.1f, 0f),
        new Vector3(0.3f, -3.0f, 0f),
        new Vector3(1.6f, -2.3f, 0f),
        new Vector3(-1.2f, -2.7f, 0f),
        new Vector3(0.9f, -2.0f, 0f),
        new Vector3(-0.8f, -3.1f, 0f),
        new Vector3(1.3f, -2.6f, 0f),
        new Vector3(0.1f, -2.2f, 0f),
        new Vector3(-1.6f, -2.8f, 0f),
        new Vector3(0.7f, -2.5f, 0f),
        new Vector3(-0.2f, -2.6f, 0f)
    };

    void Start()
    {
        if (calmMusicAudio != null && !calmMusicAudio.isPlaying)
        {
            calmMusicAudio.loop = true;
            calmMusicAudio.Play();
        }

        StartCoroutine(PlayFriendScene());
    }

    private IEnumerator PlayFriendScene()
    {
        friendDog.position = playPositions[0];
        friendDog.localScale = friendDogScale;

        if (mainPetRenderer != null && mainPetPlaySprite != null)
        {
            mainPetRenderer.sprite = mainPetPlaySprite;
            mainPetRenderer.transform.localScale = mainPetPlayScale;
        }

        if (dogBarkAudio != null)
        {
            StartCoroutine(PlayDogBarks());
        }

        if (friendAnimator != null)
        {
            friendAnimator.Play("CompanionDog_Run");
        }

        for (int i = 1; i < playPositions.Length; i++)
        {
            Vector3 target = playPositions[i];
            FlipDogToTarget(target);

            while (Vector3.Distance(friendDog.position, target) > 0.05f)
            {
                friendDog.position = Vector3.MoveTowards(
                    friendDog.position,
                    target,
                    moveSpeed * Time.deltaTime
                );

                yield return null;
            }

            yield return new WaitForSeconds(waitAtPoint);
        }

        FaceMainPet();

        if (friendAnimator != null)
        {
            friendAnimator.Play("CompanionDog_Idle");
        }
    }

    private IEnumerator PlayDogBarks()
    {
        dogBarkAudio.Play();

        yield return new WaitForSeconds(2f);

        dogBarkAudio.Play();
    }

    private void FlipDogToTarget(Vector3 target)
    {
        Vector3 scale = friendDog.localScale;

        if (target.x > friendDog.position.x)
            scale.x = Mathf.Abs(friendDogScale.x);
        else
            scale.x = -Mathf.Abs(friendDogScale.x);

        friendDog.localScale = scale;
    }

    private void FaceMainPet()
    {
        Vector3 scale = friendDog.localScale;

        if (mainPetRenderer != null &&
            mainPetRenderer.transform.position.x > friendDog.position.x)
        {
            scale.x = Mathf.Abs(friendDogScale.x);
        }
        else
        {
            scale.x = -Mathf.Abs(friendDogScale.x);
        }

        friendDog.localScale = scale;
    }

    public void ReturnToPetRoom()
    {
        if (buttonClickAudio != null)
        {
            buttonClickAudio.Play();
        }

        SceneManager.LoadScene("PetRoom_Level1");
    }
}