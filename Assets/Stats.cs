using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatType
{
    Attack,
    Speed,
    Defense
}

public class Stats : MonoBehaviour
{
    public static Stats Instance;

    public float amountIncreaseModifier = 1.5f;
    public int baseScrapCost = 20;
    public int baseAttackCost = 1;
    public int baseDefenseCost = 1;
    public int baseSpeedCost = 1;

    [HideInInspector]
    public int currentScrapCost;
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
        currentScrapCost = baseScrapCost;
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
                currentScrapCost = Mathf.RoundToInt(amountIncreaseModifier * currentScrapCost);
                attackModifier += .1f;
                break;
            case StatType.Defense:
                if (defenseModifier >= 1.5f)
                    return;
                currentDefenseCost = Mathf.RoundToInt(amountIncreaseModifier * currentDefenseCost);
                currentScrapCost = Mathf.RoundToInt(amountIncreaseModifier * currentScrapCost);
                defenseModifier += .1f;
                break;
            case StatType.Speed:
                if (speedModifier >= 1.5f)
                    return;
                currentSpeedCost = Mathf.RoundToInt(amountIncreaseModifier * currentSpeedCost);
                currentScrapCost = Mathf.RoundToInt(amountIncreaseModifier * currentScrapCost);
                speedModifier += .1f;
                break;
        }
    }
}
