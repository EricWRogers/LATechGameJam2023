using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFillController : MonoBehaviour
{
    public float lerpSpeed = 1f;

    public Image staminaFill;
    public Image healthFill;
    public Image shieldFill;

    private float time;
    private float currentVelocity;

    private void Update()
    {
        staminaFill.fillAmount = FindObjectOfType<NewShipController>().GetNormalizedBoost();
        healthFill.fillAmount = FindObjectOfType<ShipHealth>().GetNormalizedHealth();
        shieldFill.fillAmount = FindObjectOfType<ShipHealth>().GetNormalizedShield();
        //time += Time.deltaTime * lerpSpeed;
        //shieldFill.fillAmount = Mathf.Lerp(shieldFill.fillAmount, FindObjectOfType<ShipHealth>().currentShield, time);
        //shieldFill.fillAmount = FindObjectOfType<ShipHealth>().GetNormalizedShield();
    }
}
