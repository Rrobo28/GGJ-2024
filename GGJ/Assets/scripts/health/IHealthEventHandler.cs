using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthEventHandler
{
    void OnDeath();
    void OnApplyDamage(int damageAmount);
    void OnApplyHeal(int healAmount);
    void OnReachMaxHealth();
}
