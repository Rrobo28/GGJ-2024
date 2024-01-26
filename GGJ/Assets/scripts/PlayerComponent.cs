using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    public Transform Transform { get; private set; }
    public HealthComponent HealthComponent { get; private set; }

    private void Start()
    {
        Transform = transform;
    }
}