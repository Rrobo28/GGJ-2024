using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{
   PlayerComponent Player;

    public GameObject TempProjecttile;
    public GameObject Spawnpoint;

    private void Start()
    {
        Player = GetComponent<PlayerComponent>();
        
    }


    private void Update()
    {
        if (Input.GetButtonDown("Punch"))
        {
            Punch();
        }
        if (Input.GetButtonDown("Throw"))
        {
            StartThrow();
        }
        else if (Input.GetButtonUp("Throw"))
        {
            ReleaseThrow();
        }
    }
    void Punch()
    {
       Player.Animation.PLayPunch();
    }

    void StartThrow()
    {
        Player.Movement.CanMove = false;
        Player.Animation.StartAim();
    }

    void ReleaseThrow()
    {
        Player.Animation.StartThrow();
    }

    public void SpawnProjectile()
    {
        GameObject NewProgectile = Instantiate(TempProjecttile, Spawnpoint.transform.position, Quaternion.identity);


        Vector2 direction = Vector2.right;

        if(Player.Movement.IsTravelingRight)
        {
            direction = -Vector2.right;
        }

        NewProgectile.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        NewProgectile.GetComponent<Rigidbody2D>().AddForce(direction * 5, ForceMode2D.Impulse);
    }
}
