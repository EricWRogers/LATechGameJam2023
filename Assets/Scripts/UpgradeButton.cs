using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    public StatType type;
    public TextMeshProUGUI scrapReqText;
    public TextMeshProUGUI typeReqText;
    public TextMeshProUGUI levelText;

    private bool maxed = false;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    public void IncrementLevel()
    {
        int currentLevel = int.Parse(levelText.text);
        Debug.Log(currentLevel);
        levelText.SetText((++currentLevel).ToString());
    }

    public void RepairHealth()
    {
        FindObjectOfType<ShipHealth>().Heal(Stats.Instance.healthRepaired);
    }

    private void Update()
    {
        if (Inventory.Instance.scrapCount < Stats.Instance.currentAttackScrapCost 
            || Inventory.Instance.scrapCount < Stats.Instance.currentDefenseScrapCost
            || Inventory.Instance.scrapCount < Stats.Instance.currentSpeedScrapCost)
        {
            scrapReqText.color = Color.red;
        }
        else if (!maxed)
        {
            scrapReqText.color = Color.white;
        }

        switch (type)
        {
            case StatType.Attack:
                typeReqText.SetText(Stats.Instance.currentAttackCost.ToString());
                scrapReqText.SetText(Stats.Instance.currentAttackScrapCost.ToString());

                if (Stats.Instance.attackModifier >= 1.5f)
                {
                    button.interactable = false;
                    typeReqText.SetText("0");
                    scrapReqText.SetText("0");
                    levelText.SetText("MAX");
                    typeReqText.color = Color.red;
                    scrapReqText.color = Color.red;
                    maxed = true;
                }

                if (Inventory.Instance.scrapCount < Stats.Instance.currentAttackScrapCost || Inventory.Instance.redCrystalCount < Stats.Instance.currentAttackCost)
                {
                    typeReqText.color = Color.red;
                    button.interactable = false;
                }
                else if (!maxed)
                {
                    typeReqText.color = Color.white;
                }
                break;
            case StatType.Defense:
                typeReqText.SetText(Stats.Instance.currentDefenseCost.ToString());
                scrapReqText.SetText(Stats.Instance.currentDefenseScrapCost.ToString());

                if (Stats.Instance.defenseModifier >= 1.5f)
                {
                    button.interactable = false;
                    typeReqText.SetText("0");
                    scrapReqText.SetText("0");
                    levelText.SetText("MAX");
                    typeReqText.color = Color.red;
                    scrapReqText.color = Color.red;
                    maxed = true;
                }

                if (Inventory.Instance.scrapCount < Stats.Instance.currentDefenseScrapCost || Inventory.Instance.blueCrystalCount < Stats.Instance.currentDefenseCost)
                {
                    typeReqText.color = Color.red;
                    button.interactable = false;
                }
                else if (!maxed)
                {
                    button.interactable = true;
                    typeReqText.color = Color.white;
                }
                break;
            case StatType.Speed:
                typeReqText.SetText(Stats.Instance.currentSpeedCost.ToString());
                scrapReqText.SetText(Stats.Instance.currentSpeedScrapCost.ToString());

                if (Stats.Instance.speedModifier >= 1.5f)
                {
                    button.interactable = false;
                    typeReqText.SetText("0");
                    scrapReqText.SetText("0");
                    levelText.SetText("MAX");
                    typeReqText.color = Color.red;
                    scrapReqText.color = Color.red;
                    maxed = true;
                }

                if (Inventory.Instance.scrapCount < Stats.Instance.currentSpeedScrapCost || Inventory.Instance.greenCrystalCount < Stats.Instance.currentSpeedCost)
                {
                    typeReqText.color = Color.red;
                    button.interactable = false;
                }
                else if (!maxed)
                {
                    button.interactable = true;
                    typeReqText.color = Color.white;
                }
                break;
            case StatType.Repair:
                scrapReqText.SetText(Stats.Instance.repairCost.ToString());

                if (Inventory.Instance.scrapCount < Stats.Instance.repairCost)
                {
                    typeReqText.color = Color.red;
                    button.interactable = false;
                }
                else
                {
                    button.interactable = true;
                    typeReqText.color = Color.white;
                }
                break;
        }
    }
}
