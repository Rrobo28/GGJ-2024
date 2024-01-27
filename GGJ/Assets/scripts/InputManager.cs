using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerComponent Player;

    public int PlayerNumber = 1;

    string Horizontal;
    string Vertical;

    string Punch;
    string Throw;

    private void Start()
    {
        Player = GetComponent<PlayerComponent>();

        string Horizontal = "Horizontal" + PlayerNumber;
        string Vertical = "Vertical" + PlayerNumber;

        string Punch = "Punch" + PlayerNumber;
        string Throw = "Throw" + PlayerNumber;
    }


    private void Update()
    {
       

    }
}
