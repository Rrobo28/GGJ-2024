using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static readonly List<PlayerComponent> AllPlayers = new List<PlayerComponent>();
    public static readonly List<GameObject> AllPlayersGameObjects = new List<GameObject>();

    private void Start()
    {
        PlayerComponent[] players = FindObjectsOfType<PlayerComponent>();

        foreach (PlayerComponent player in players)
        {
            AllPlayers.Add(player);
            AllPlayersGameObjects.Add(player.gameObject);
        }
    }
}