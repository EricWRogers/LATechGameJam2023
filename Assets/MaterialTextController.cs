using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaterialTextController : MonoBehaviour
{
    public TextMeshProUGUI scrapText;
    public TextMeshProUGUI greenCrystalText;
    public TextMeshProUGUI blueCrystalText;
    public TextMeshProUGUI redCrystalText;

    private void Start()
    {
        Inventory.Instance.onInventoryChanged.AddListener(ChangeText);
    }

    public void ChangeText(int newCount, PickupType type)
    {
        switch(type)
        {
            case PickupType.Scrap:
                scrapText.SetText(newCount.ToString());
                break;
            case PickupType.GreenCrystal:
                greenCrystalText.SetText(newCount.ToString());
                break;
            case PickupType.BlueCrystal:
                blueCrystalText.SetText(newCount.ToString());
                break;
            case PickupType.RedCrystal:
                redCrystalText.SetText(newCount.ToString());
                break;
        }
    }
}
