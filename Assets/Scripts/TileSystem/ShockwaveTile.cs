using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class ShockwaveTile : MonoBehaviour
{
    private PlayerController player;
    private Tile tile;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        tile = GetComponent<Tile>();
    }

    public void Update()
    {
        if (tile.hasPlayer)
        {
            player.DamagePlayer(20);
        }
    }
}
