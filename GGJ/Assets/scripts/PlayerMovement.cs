using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    bool CanJump = true;
    int JumpCounter = 2;

    [SerializeField]
    private float WalkSpeed = 2.0f;

    Rigidbody2D ThisBody;

    float distToGround = 0.0f;

    bool IsTravelingRight = true;

    public enum PlayerMoveStates { Idle,Walking,Jumping,Falling}

    public PlayerMoveStates State = PlayerMoveStates.Idle;


    void Start()
    {
        JumpCounter = 2;
        distToGround =  GetComponent<BoxCollider2D>().bounds.extents.y;
        ThisBody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0,0);

        if (movement.x > 0 && IsTravelingRight)
        {
            SwapDirection();
        }
        else if (movement.x < 0 && !IsTravelingRight)
        {
            SwapDirection();
        }

            transform.Translate(movement * WalkSpeed * Time.deltaTime);

        Debug.DrawRay(transform.position, -Vector3.up* (distToGround ), Color.blue);
        GroundedCheck();

        if (Input.GetButtonDown("Jump") && JumpCounter > 0)
        {
            Jump();
        }

    }

    void SwapDirection()
    {
        IsTravelingRight = !IsTravelingRight;

        if(IsTravelingRight)
        {
            transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    public void GroundedCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, (distToGround), LayerMask.GetMask("Level"));

        if (hit.collider)
        {
            if(ThisBody.velocity.y <0 && JumpCounter == 0)
            JumpCounter = 2;
        }


    }
    void Jump()
    {
        ThisBody.velocity = Vector3.zero;   
        ThisBody.AddForce(Vector3.up * 5, ForceMode2D.Impulse);
        JumpCounter--;
    }
}
