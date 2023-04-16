using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SuperPupSystems.Helper;

public class ShipHealth : MonoBehaviour
{
    public float timeToStartRegen = 3f;
    public float shieldRegenInterval = 1f;
    public int maxHealth = 100;
    public int maxShield = 100;
    public Timer regenStartTimer;
    public Timer shieldRegenTimer;

    public UnityEvent onHurt = new UnityEvent();
    public UnityEvent onDie = new UnityEvent();

    [HideInInspector]
    public int currentHealth;
    [HideInInspector]
    public int currentShield;
    private bool shieldsUp = true;

    private void Start()
    {
        currentHealth = maxHealth;
        currentShield = maxShield;

        regenStartTimer.TimeOut.AddListener(StartShieldRegen);
        shieldRegenTimer.TimeOut.AddListener(AddShield);
        onHurt.AddListener(StopShieldRegen);
    }

    public void Damage(int amount)
    {
        if (currentShield <= 0)
        {
            shieldsUp = false;
            currentHealth -= amount;
        }

        if (amount > currentShield && shieldsUp)
        {
            int overDamage = amount - currentShield;
            currentShield -= amount;
            currentHealth -= overDamage;
        }
        else
        {
            currentShield -= amount;
        }

        if (currentHealth <= 0f)
        {
            onDie.Invoke();
        }

        regenStartTimer.StartTimer(timeToStartRegen, false);
    }

    private void StartShieldRegen()
    {
        shieldRegenTimer.StartTimer(shieldRegenInterval, true);
    }

    public void AddShield()
    {
        currentShield++;
        shieldsUp = true;
    }

    public void StopShieldRegen()
    {
        shieldRegenTimer.StopTimer();
    }

    public float GetNormalizedHealth()
    {
        return (float)currentHealth / maxHealth;
    }

    public float GetNormalizedShield()
    {
        return (float)currentShield / maxShield;
    }

    private void Update()
    {
        currentShield = Mathf.RoundToInt(Mathf.Clamp(currentShield, 0f, maxShield));

        if (currentShield == maxShield)
        {
            shieldRegenTimer.StopTimer();
        }
    }
}
