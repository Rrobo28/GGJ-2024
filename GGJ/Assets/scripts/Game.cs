using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static readonly List<PlayerComponent> AllPlayers = new List<PlayerComponent>();

    private void Awake()
    {
        PlayerComponent[] players = FindObjectsOfType<PlayerComponent>();

        foreach (PlayerComponent player in players)
        {
            AllPlayers.Add(player);
        }
    }
}