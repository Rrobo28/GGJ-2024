using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrelComponent : MonoBehaviour
{
    private Transform Transform;

    [SerializeField]
    private float TimeUntilExplosionSeconds = 3.0f;

    [SerializeField]
    private float ExplosionRadius = 10.0f;
    private float ExplosionRadiusSq;

    [SerializeField]
    private float TooltipRadius = 10.0f;
    private float TooltipRadiusSq;

    [SerializeField]
    private int ExplosionDamage = 25;

    private bool IsActive;
    private bool IsDisplayingTooltip;

    private void Start()
    {
        Transform = transform;
        ExplosionRadiusSq = ExplosionRadius * ExplosionRadius;
        TooltipRadiusSq = TooltipRadius * TooltipRadius;
    }

    private void Update()
    {
        if (IsActive)
        {
            TimeUntilExplosionSeconds -= Time.deltaTime;

            bool isExploding = TimeUntilExplosionSeconds <= 0.0f;

            if (isExploding)
            {
                Explode();
            }
        }
        else
        {
            IsDisplayingTooltip = false;

            for (int i = 0; i < Game.AllPlayers.Count && !IsActive; ++i)
            {
                PlayerComponent player = Game.AllPlayers[i];
                if (!IsDisplayingTooltip)
                {
                    if (CheckShouldDisplayToolTip(player))
                    {
                        IsDisplayingTooltip = true;
                    }
                }

                if (CheckShouldActivateCountdown(player))
                {
                    IsActive = true;
                    IsDisplayingTooltip = false;
                }    
            }
        }
    }

    private void Explode()
    {
        foreach (PlayerComponent player in Game.AllPlayers)
        {
            if (IsPlayerWithinExplosionRadius(player))
            {
                player.HealthComponent.ApplyDamage(ExplosionDamage);
            }
        }
    }

    private bool IsPlayerWithinExplosionRadius(PlayerComponent player)
    {
        return Util.IsWithinDistance(Transform, player.Transform, ExplosionRadiusSq);
    }

    private bool CheckShouldDisplayToolTip(PlayerComponent player)
    {
        return Util.IsWithinDistance(Transform, player.Transform, TooltipRadiusSq);
    }

    private bool CheckShouldActivateCountdown(PlayerComponent player)
    {
        return false;
    }
}