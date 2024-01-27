using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    PlayerComponent Player;

    private void Start()
    {
        Player = GetComponent<PlayerComponent>();
    }

    public void SetState(int value)
    {
        Player.Animator.SetInteger("State", value);
    }
    public void PLayPunch()
    {
        Player.Animator.SetBool("Punching", true);
    }
    public void StopPunch()
    {
        Player.Animator.SetBool("Punching", false);
    }

    public void SetPushing(bool value)
    {
        Player.Animator.SetBool("Pushing", value);
    }

    public void StartAim()
    {
        Player.Animator.SetBool("Aiming", true);
    }
    public void StartThrow()
    {
        Player.Animator.SetBool("Throwing", true);
        Player.Animator.SetBool("Aiming", false);
    }
    public void EndThrow()
    {
        Player.Animator.SetBool("Throwing", false);
        

        Player.Movement.CanMove = true;
    }
}
