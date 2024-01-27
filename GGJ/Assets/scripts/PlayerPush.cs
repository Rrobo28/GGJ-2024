using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    PlayerComponent Player;
   


    public bool Facing()
    {
       
        Vector3 position;
        if (!Player.Movement.IsTravelingRight)
        {
            position = new Vector3(transform.position.x + GetComponent<BoxCollider2D>().bounds.extents.x, transform.position.y , transform.position.z);
        }
        else
        {
            position = new Vector3(transform.position.x-GetComponent<BoxCollider2D>().bounds.extents.x, transform.position.y, transform.position.z);
        }

        Collider2D hit = Physics2D.OverlapCircle(position, 0.5f, LayerMask.GetMask("MoveableObject"));


        if (hit)
        {
            return true;
        }
        else
        {
            return false;
        }


    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(Facing());

        if (collision.gameObject.CompareTag("Moveable")&& Facing())
        {
            Player.Animation.SetPushing(true);
        }
        else
        {
            Player.Animation.SetPushing(false);
        }
    }
}
