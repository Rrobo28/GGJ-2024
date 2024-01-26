using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator ThisAnimator;
    void Start()
    {
        ThisAnimator = GetComponent<Animator>();
    }


    public void SetState(int value)
    {
        ThisAnimator.SetInteger("State", value);
    }

    
}
