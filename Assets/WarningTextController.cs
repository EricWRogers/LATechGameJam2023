using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WarningTextController : MonoBehaviour
{
    public TextMeshProUGUI warningText;
    public CanvasGroup warningElement;

    public float fadeTime = 5f;
    public float lowAlphaValue = .3f;

    [TextArea]
    public string firstWarningMessage;

    [TextArea]
    public string secondWarningMessage;

    private void Start()
    {
        warningText.SetText(firstWarningMessage);
        FindObjectOfType<Transmitter>().finalDistanceWarning.AddListener(ChangeText);

        warningElement.LeanAlpha(lowAlphaValue, fadeTime).setOnComplete(FadeToFull);
    }

    public void FadeToFull()
    {
        warningElement.LeanAlpha(1f, fadeTime).setOnComplete(FadeToEmpty);
    }

    public void FadeToEmpty()
    {
        warningElement.LeanAlpha(lowAlphaValue, fadeTime).setOnComplete(FadeToFull);
    }

    public void ChangeText()
    {
        warningText.SetText(secondWarningMessage);
    }
}
