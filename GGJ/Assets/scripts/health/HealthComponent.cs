using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : EventProvider<IHealthEventHandler>
{
    private int Health;

    [SerializeField]
    private int MaximumHealth;

    private void Start()
    {
        Health = MaximumHealth;
    }

    public void ApplyDamage(int damageAmount)
    {
        EventHandler.OnApplyDamage(damageAmount);

        Health -= Mathf.Min(Health, damageAmount);
        
        bool isDead = Health == 0;

        if (isDead)
        {
            EventHandler.OnDeath();
        }
    }

    public void ApplyHeal(int healAmount)
    {
        EventHandler.OnApplyHeal(healAmount);

        bool isAlreadyMaxHealth = Health == MaximumHealth;

        Health += healAmount;

        bool isOverMaxHealth = Health > MaximumHealth;

        if (isOverMaxHealth)
        {
            Health = MaximumHealth;
        }

        bool isMaxHealth = Health == MaximumHealth;

        if (isMaxHealth && !isAlreadyMaxHealth)
        {
            EventHandler.OnReachMaxHealth();
        }
    }
}
