using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatType
{
    Attack,
    Speed,
    Defense,
    Repair
}

public class Stats : MonoBehaviour
{
    public static Stats Instance;

    public float amountIncreaseModifier = 1.5f;
    public int baseScrapCost = 5;
    public int baseAttackCost = 1;
    public int baseDefenseCost = 1;
    public int baseSpeedCost = 1;
    public int repairCost = 10;
    public int healthRepaired = 20;

    [HideInInspector]
    public int currentAttackScrapCost;
    [HideInInspector]
    public int currentDefenseScrapCost;
    [HideInInspector]
    public int currentSpeedScrapCost;
    [HideInInspector]
    public int currentAttackCost;
    [HideInInspector]
    public int currentDefenseCost;
    [HideInInspector]
    public int currentSpeedCost;

    [Range(1.0f, 1.5f)]
    public float attackModifier = 1.0f;
    [Range(1.0f, 1.5f)]
    public float speedModifier = 1.0f;
    [Range(1.0f, 1.5f)]
    public float defenseModifier = 1.0f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        currentAttackCost = baseAttackCost;
        currentDefenseCost = baseDefenseCost;
        currentSpeedCost = baseSpeedCost;
        currentAttackScrapCost = baseScrapCost;
        currentDefenseScrapCost = baseScrapCost;
        currentSpeedScrapCost = baseScrapCost;
    }

    public void IncreaseStat(int index)
    {
        StatType type = (StatType)index;

        switch (type)
        {
            case StatType.Attack:
                if (attackModifier >= 1.5f)
                    return;
                currentAttackCost = Mathf.RoundToInt(amountIncreaseModifier * currentAttackCost);
                currentAttackScrapCost = Mathf.RoundToInt(amountIncreaseModifier * currentAttackScrapCost);
                attackModifier += .1f;
                break;
            case StatType.Defense:
                if (defenseModifier >= 1.5f)
                    return;
                currentDefenseCost = Mathf.RoundToInt(amountIncreaseModifier * currentDefenseCost);
                currentDefenseScrapCost = Mathf.RoundToInt(amountIncreaseModifier * currentDefenseScrapCost);
                defenseModifier += .1f;
                break;
            case StatType.Speed:
                if (speedModifier >= 1.5f)
                    return;
                currentSpeedCost = Mathf.RoundToInt(amountIncreaseModifier * currentSpeedCost);
                currentSpeedScrapCost = Mathf.RoundToInt(amountIncreaseModifier * currentSpeedScrapCost);
                speedModifier += .1f;
                break;
        }

        if (attackModifier >= 1.5f && defenseModifier >= 1.5f && speedModifier >= 1.5f)
        {
            FindObjectOfType<Transmitter>().UnlockAllUpgrades();
        }
    }
}
