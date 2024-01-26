using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTimeObjectComponent : MonoBehaviour
{
    [SerializeField]
    private int DotTickDamage = 10;

    [SerializeField]
    private float DotTickIntervalSeconds = 1.0f;

    private Dictionary<GameObject, float> Timers;

    private void Start()
    {
        Timers = new Dictionary<GameObject, float>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        bool isPlayer = Game.AllPlayersGameObjects.Contains(collision.gameObject);

        if (isPlayer)
        {
            PlayerComponent player = collision.gameObject.GetComponent<PlayerComponent>();

            if (!Timers.ContainsKey(collision.gameObject))
            {
                Timers.Add(collision.gameObject, DotTickIntervalSeconds);
            }
            else
            {
                Timers[collision.gameObject] -= Time.deltaTime;

                if (Timers[collision.gameObject] <= 0.0f)
                {
                    player.HealthComponent.ApplyDamage(DotTickDamage);
                    Timers[collision.gameObject] = DotTickIntervalSeconds;
                }
            }
        }
    }
}
