using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    bool CanJump = true;

    [SerializeField]
    private float WalkSpeed = 2.0f;

    Rigidbody2D ThisBody;

    float distToGround = 0.0f;


    void Start()
    {
       
        distToGround =  GetComponent<BoxCollider2D>().bounds.extents.y;
        ThisBody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0,0);
        transform.Translate(movement * WalkSpeed * Time.deltaTime);

        Debug.DrawRay(transform.position, -Vector3.up* (distToGround ), Color.blue);

        if (Grounded() && Input.GetButton("Jump") && CanJump)
        {
            Jump();
        }

    }

    public bool Grounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, (distToGround ),LayerMask.GetMask("Level"));

        if (hit.collider)
        {
            if(!CanJump && ThisBody.velocity.y<0)
            {
                CanJump = true;
            }
            return true;
           
        }
        else
        {
            return false;
        }
    }


    void Jump()
    {
        ThisBody.AddForce(Vector3.up * 10, ForceMode2D.Impulse);
        CanJump = false;
    }
}
