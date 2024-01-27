using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerComponent Player;

    public bool CanMove = true;

    bool IsGrounded = false;
    float distToGround = 0.0f;
    
    public bool IsTravelingRight = false;

    [SerializeField,Header("Ground Check")]
    private float GroundSize = 0.5f;

    [SerializeField,Header("Move Values")]
    private float WalkSpeed = 2.0f;
    [SerializeField]
    private float JumpForce = 5.0f;
   
    int JumpCounter = 2;
    public enum PlayerMoveStates { Idle,Walking,Jumping,Falling}
    [Header("Player State")]
    public PlayerMoveStates State = PlayerMoveStates.Idle;


    void Start()
    {
        Player = GetComponent<PlayerComponent>();
        
        JumpCounter = 2;
        distToGround =  GetComponent<BoxCollider2D>().bounds.extents.y;
        
    }

    
    void Update()
    {
        Player.Animation.SetState((int)State);

       
        GroundedCheck();

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0,0);

        if(movement == Vector3.zero && IsGrounded)
        {
            State = PlayerMoveStates.Idle;
        }
        else if(IsGrounded) 
        {
            State = PlayerMoveStates.Walking;
        }

        if(Player.Rigidbody.velocity.y <0 && !IsGrounded)
        {
            State = PlayerMoveStates.Falling;
        }
        else if (Player.Rigidbody.velocity.y > 0 && !IsGrounded)
        {
            State = PlayerMoveStates.Jumping;
        }


        if (movement.x > 0 && IsTravelingRight)
        {
            SwapDirection();
        }
        else if (movement.x < 0 && !IsTravelingRight)
        {
            SwapDirection();
        }

        if (!CanMove) return;

        transform.Translate(movement * WalkSpeed * Time.deltaTime);

        Debug.DrawRay(transform.position, -Vector3.up* (distToGround ), Color.blue);
       

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

    void OnDrawGizmosSelected()
    {
        Vector3 position = new Vector3(transform.position.x - GetComponent<BoxCollider2D>().bounds.extents.x, transform.position.y , transform.position.z);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(position, GroundSize);
    }

    public void GroundedCheck()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, (distToGround + 0.5f), LayerMask.GetMask("Level"));

        Vector3 position = new Vector3(transform.position.x,transform.position.y - GetComponent<BoxCollider2D>().bounds.extents.y,transform.position.z);

        Collider2D hit = Physics2D.OverlapCircle(position, GroundSize, LayerMask.GetMask("Level"));


        if (hit)
        {
            if(Player.Rigidbody.velocity.y <0 && JumpCounter == 0)
            JumpCounter = 2;
            
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }
    void Jump()
    {
        Player.Rigidbody.velocity = Vector3.zero;
        Player.Rigidbody.AddForce(Vector3.up * JumpForce, ForceMode2D.Impulse);
        JumpCounter--;
    }
}
