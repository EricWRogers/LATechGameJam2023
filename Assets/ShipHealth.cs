using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using OmnicatLabs.Managers;

public class ShipHealth : MonoBehaviour
{
    public float timeToStartRegen = 3f;
    public float shieldRegenInterval = 1f;
    public int maxHealth = 100;
    public int maxShield = 100;

    public UnityEvent onHurt = new UnityEvent();
    public UnityEvent onDie = new UnityEvent();

    [HideInInspector]
    public int currentHealth;
    [HideInInspector]
    public int currentShield;
    private bool regen = false;

    private void Start()
    {
        currentHealth = maxHealth;
        currentShield = maxShield;
    }

    public void Damage(int amount)
    {
        if (amount > currentShield)
        {
            int overDamage = currentShield - amount;
            currentShield -= amount;
            currentHealth -= overDamage;
        }
        else
        {
            currentShield -= amount;
        }

        TimerManager.Instance.CreateTimer(timeToStartRegen, StartShieldRegen);
    }

    private void StartShieldRegen()
    {
        TimerManager.Instance.CreateTimer(shieldRegenInterval, AddShield, true);
    }

    public void AddShield()
    {
        currentShield++;
    }

    private void Update()
    {
        
    }
}
