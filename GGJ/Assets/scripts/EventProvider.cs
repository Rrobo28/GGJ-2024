using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventProvider<T> : MonoBehaviour
{
    protected T EventHandler { get; private set; }
    private void Awake()
    {
        EventHandler = gameObject.GetComponent<T>();
    }
}