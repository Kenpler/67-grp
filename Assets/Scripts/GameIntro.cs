using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameIntro : MonoBehaviour
{
    [SerializeField] private Image blackOverlay;
    [SerializeField] private TMP_Text instructionText;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private string correctPhrase = "begin";
    [SerializeField] private float fadeDuration = 2f;

    private void Start()
    {
        inputField.onValueChanged.AddListener(OnInputChanged);
    }

    private void OnInputChanged(string input)
    {
        if (input.Trim().ToLower() == correctPhrase.ToLower())
        {
            inputField.interactable = false;
            StartCoroutine(FadeOutElements());
        }
    }

    private System.Collections.IEnumerator FadeOutElements()
    {
float elapsed = 0f;
    Color overlayColor = blackOverlay.color;
    Color textColor = instructionText.color;

    // InputField visuals
    Image inputImage = inputField.GetComponent<Image>();
    Color inputImageColor = inputImage.color;

    TMP_Text placeholder = inputField.placeholder as TMP_Text;
    TMP_Text inputText = inputField.textComponent;

    Color placeholderColor = placeholder.color;
    Color inputTextColor = inputText.color;

    while (elapsed < fadeDuration)
    {
        float t = elapsed / fadeDuration;

        blackOverlay.color = new Color(overlayColor.r, overlayColor.g, overlayColor.b, Mathf.Lerp(overlayColor.a, 0f, t));
        instructionText.color = new Color(textColor.r, textColor.g, textColor.b, Mathf.Lerp(textColor.a, 0f, t));

        inputImage.color = new Color(inputImageColor.r, inputImageColor.g, inputImageColor.b, Mathf.Lerp(inputImageColor.a, 0f, t));
        placeholder.color = new Color(placeholderColor.r, placeholderColor.g, placeholderColor.b, Mathf.Lerp(placeholderColor.a, 0f, t));
        inputText.color = new Color(inputTextColor.r, inputTextColor.g, inputTextColor.b, Mathf.Lerp(inputTextColor.a, 0f, t));

        elapsed += Time.deltaTime;
        yield return null;
    }
    }
}
