using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    public Transform Transform { get; private set; }
    public HealthComponent HealthComponent { get; private set; }

    public PlayerMovement Movement { get; private set; }
    public PlayerAnimation Animation { get; private set; }
    public PlayerAttack Attack { get; private set; }
    public PlayerPush Push { get; private set; }

    public Rigidbody2D Rigidbody { get; private set; }
    public SpriteRenderer SpriteRenderer { get; private set; }
    public BoxCollider2D BoxCollider { get; private set; }

    public Animator Animator { get; private set; }

    private void Start()
    {
        Transform = transform;
        HealthComponent = GetComponent<HealthComponent>();

        Movement = GetComponent<PlayerMovement>();  
        Animation = GetComponent<PlayerAnimation>();    
        Attack = GetComponent<PlayerAttack>();  
        Push = GetComponent<PlayerPush>();

        Rigidbody = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider = GetComponent<BoxCollider2D>();
        Animator = GetComponent<Animator>();
    }
}