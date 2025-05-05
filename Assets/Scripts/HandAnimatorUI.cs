using UnityEngine;
using UnityEngine.UI;

public class HandAnimatorUI : MonoBehaviour
{
    [SerializeField] private RectTransform handRect;
    [SerializeField] private float idleAmplitude = 10f;
    [SerializeField] private float idleSpeed = 2f;
    [SerializeField] private float pressedYOffset = -30f;
    [SerializeField] private float transitionSpeed = 5f;
    [SerializeField] private float returnDelay = 0.3f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip keyboardSound;

    private bool soundPlayed;
    private Vector2 originalPos;
    private float time;
    private float lastKeyTime;
    private bool isPressed;

    private void Start()
    {
        if (handRect == null) handRect = GetComponent<RectTransform>();
        originalPos = handRect.anchoredPosition;
    }

    private void Update()
    {
    if (Input.inputString.Length > 0)
    {
        isPressed = true;
        lastKeyTime = Time.time;

        if (!soundPlayed && keyboardSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(keyboardSound);
            soundPlayed = true;
        }
    }

    if (isPressed && Time.time - lastKeyTime > returnDelay)
    {
        isPressed = false;
        soundPlayed = false; // reset so next key press can play sound again
    }

    AnimateHand();
    }

    private void AnimateHand()
    {
        Vector2 targetPos;

        if (isPressed)
        {
            targetPos = originalPos + Vector2.up * pressedYOffset;
        }
        else
        {
            float offsetY = Mathf.Sin(time * idleSpeed) * idleAmplitude;
            targetPos = originalPos + Vector2.up * offsetY;
            time += Time.deltaTime;
        }

        handRect.anchoredPosition = Vector2.Lerp(handRect.anchoredPosition, targetPos, Time.deltaTime * transitionSpeed);
    }
}
