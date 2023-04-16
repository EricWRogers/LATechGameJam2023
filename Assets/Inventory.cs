using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InventoryChangedEvent : UnityEvent<int, PickupType> { }

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public InventoryChangedEvent onInventoryChanged = new InventoryChangedEvent();

    //[HideInInspector]
    public int scrapCount;
    //[HideInInspector]
    public int greenCrystalCount;
    //[HideInInspector]
    public int blueCrystalCount;
    //[HideInInspector]
    public int redCrystalCount;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void Add(PickupType type, int amount)
    {
        switch(type)
        {
            case PickupType.Scrap:
                scrapCount += amount;
                onInventoryChanged.Invoke(scrapCount, PickupType.Scrap);
                break;
            case PickupType.GreenCrystal:
                greenCrystalCount += amount;
                onInventoryChanged.Invoke(greenCrystalCount, PickupType.GreenCrystal);
                break;
            case PickupType.BlueCrystal:
                blueCrystalCount += amount;
                onInventoryChanged.Invoke(blueCrystalCount, PickupType.BlueCrystal);
                break;
            case PickupType.RedCrystal:
                redCrystalCount += amount;
                onInventoryChanged.Invoke(redCrystalCount, PickupType.RedCrystal);
                break;
        }
    }
}
