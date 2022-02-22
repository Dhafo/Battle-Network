
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Ranged/Minibomb")]
public class Minibomb : Spell
{
    public override void CastSpell(PlayerController player, BoardController bc)
    {
        int locationX = player.gridX + 3;
        int locationZ = player.gridZ;
        if (locationX <= 5 && bc.tiles[locationX, locationZ].hasEnemy)
        {
        bc.tiles[locationX, locationZ].enemy.GetComponent<ShockwaveEnemy>().Damage(damage);
        }
        damage = 50;

    }
}