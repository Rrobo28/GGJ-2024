using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField]
    private float WalkSpeed = 2.0f;

    Rigidbody2D thisBody;


    void Start()
    {
        thisBody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0,0);
        transform.Translate(movement* WalkSpeed * Time.deltaTime);

        Debug.DrawRay(transform.position, -Vector3.up * 4);
    }

    bool Grounded()
    {
        return true;

        

    }


    void Jump()
    {
        
    }
}
