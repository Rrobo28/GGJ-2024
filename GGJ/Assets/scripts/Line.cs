using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    Rigidbody2D Body;
    LineRenderer Renderer;
    void Start()
    {
        Renderer = GetComponent<LineRenderer>();   
        Body = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
