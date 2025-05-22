using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PasswordToggle : MonoBehaviour
{
    public TMP_InputField passwordField;
    // public Sprite showIcon;
    // public Sprite hideIcon;
    // public Image toggleIcon;

    private bool isHidden = true;

    public void TogglePasswordVisibility()
    {
        isHidden = !isHidden;
        passwordField.contentType = isHidden ? TMP_InputField.ContentType.Password : TMP_InputField.ContentType.Standard;
        // toggleIcon.sprite = isHidden ? showIcon : hideIcon;

        // Force refresh field
        passwordField.ForceLabelUpdate();
    }
}
