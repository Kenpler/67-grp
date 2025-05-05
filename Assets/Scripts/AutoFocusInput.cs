using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class AutoFocusInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField firstInputField;
    [SerializeField] private TMP_InputField secondInputField;

    private void Start()
    {
        // Focus the first input at the start
        EventSystem.current.SetSelectedGameObject(firstInputField.gameObject);

        // When first input ends, move focus to second
        firstInputField.onEndEdit.AddListener(HandleFirstInputEnd);
    }

    private void HandleFirstInputEnd(string text)
    {
        EventSystem.current.SetSelectedGameObject(secondInputField.gameObject);
    }
}
