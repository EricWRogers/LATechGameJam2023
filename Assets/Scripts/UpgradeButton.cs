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
        Debug.Log(currentLevel++.ToString());
    }

    private void Update()
    {
        if (Inventory.Instance.scrapCount < Stats.Instance.currentScrapCost)
        {
            scrapReqText.color = Color.red;
        }
        else
        {
            scrapReqText.color = Color.white;
        }

        switch (type)
        {
            case StatType.Attack:
                typeReqText.SetText(Stats.Instance.currentAttackCost.ToString());
                scrapReqText.SetText(Stats.Instance.currentScrapCost.ToString());

                if (Inventory.Instance.scrapCount < Stats.Instance.currentScrapCost || Inventory.Instance.redCrystalCount < Stats.Instance.currentAttackCost)
                {
                    typeReqText.color = Color.red;
                    button.interactable = false;
                }
                else
                {
                    typeReqText.color = Color.white;
                }
                break;
            case StatType.Defense:
                typeReqText.SetText(Stats.Instance.currentDefenseCost.ToString());
                scrapReqText.SetText(Stats.Instance.currentScrapCost.ToString());

                if (Inventory.Instance.scrapCount < Stats.Instance.currentScrapCost || Inventory.Instance.blueCrystalCount < Stats.Instance.currentDefenseCost)
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
            case StatType.Speed:
                typeReqText.SetText(Stats.Instance.currentSpeedCost.ToString());
                scrapReqText.SetText(Stats.Instance.currentScrapCost.ToString());

                if (Inventory.Instance.scrapCount < Stats.Instance.currentScrapCost || Inventory.Instance.greenCrystalCount < Stats.Instance.currentSpeedCost)
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
