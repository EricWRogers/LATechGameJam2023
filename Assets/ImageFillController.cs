using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFillController : MonoBehaviour
{
    public Image staminaFill;

    private void Update()
    {
        staminaFill.fillAmount = FindObjectOfType<NewShipController>().GetNormalizedBoost();
    }
}
