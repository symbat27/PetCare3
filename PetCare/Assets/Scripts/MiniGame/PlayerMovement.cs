using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f;

    public float minX = -2.1f;
    public float maxX = 2.1f;

    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        float move = 0f;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            move = -1f;
        }

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            move = 1f;
        }

        targetPosition += Vector3.right * move * speed * Time.deltaTime;

        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            10f * Time.deltaTime
        );
    }
}
