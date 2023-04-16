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
    private Color originalColor;

    private void Start()
    {
        warningText.SetText(firstWarningMessage);
        originalColor = warningText.color;
        FindObjectOfType<Transmitter>().finalDistanceWarning.AddListener(ChangeText);

        warningElement.LeanAlpha(lowAlphaValue, fadeTime).setOnComplete(FadeToFull);
    }


    void updateValueExampleCallback(Color val)
    {
        warningText.color = val;
    }

    public void FadeToFull()
    {
        LeanTween.value(gameObject, updateValueExampleCallback, Color.red, originalColor, 1f).setOnComplete(FadeToEmpty);//);
        warningElement.LeanAlpha(1f, fadeTime);//.setOnComplete(FadeToEmpty);
    }

    public void FadeToEmpty()
    {
        LeanTween.value(gameObject, updateValueExampleCallback, originalColor, Color.red, 1f).setOnComplete(FadeToFull);//.setEase(LeanTweenType.easeOutElastic);
        warningElement.LeanAlpha(lowAlphaValue, fadeTime);
    }

    public void ChangeText()
    {
        warningText.SetText(secondWarningMessage);
    }
}
