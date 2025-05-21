using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoginUIManager : MonoBehaviour
{
    [Header("Input Fields")]
    public TMP_InputField phoneInput;
    public TMP_InputField passwordInput;

    [Header("Validation Texts")]
    public TMP_Text phoneErrorText;
    public TMP_Text passwordErrorText;

    [Header("Login Button")]
    public Button loginButton;

    private void Start()
    {
        phoneErrorText.gameObject.SetActive(false);
        passwordErrorText.gameObject.SetActive(false);

        loginButton.onClick.AddListener(OnLoginPressed);

        loginButton.interactable = false;

        // Update button interactability as user types
        phoneInput.onValueChanged.AddListener(_ => ValidateInputLive());
        passwordInput.onValueChanged.AddListener(_ => ValidateInputLive());
    }

    private void ValidateInputLive()
    {
        loginButton.interactable =
            phoneInput.text.Length == 10 &&
            !string.IsNullOrEmpty(passwordInput.text);
    }

    public void OnLoginPressed()
    {
        bool isValid = true;

        // Validate phone
        if (!LoginValidator.IsValidPhone(phoneInput.text))
        {
            phoneErrorText.text = "Phone number must be 10 digits";
            phoneErrorText.gameObject.SetActive(true);
            isValid = false;
        }
        else
        {
            phoneErrorText.gameObject.SetActive(false);
        }

        // Validate password
        if (!LoginValidator.IsValidPassword(passwordInput.text))
        {
            passwordErrorText.text = "Password cannot be empty";
            passwordErrorText.gameObject.SetActive(true);
            isValid = false;
        }
        else
        {
            passwordErrorText.gameObject.SetActive(false);
        }

        if (!isValid)
            return;

        // Proceed to next screen
        GameManager.instance.sceneLoader.LoadSceneWithLoading("MainMenuScene");
    }
}
