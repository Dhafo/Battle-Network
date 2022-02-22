using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Melee/WideSword")]
public class WideSword : Spell
{
    public override void CastSpell(PlayerController player, BoardController bc)
    {

        int locationX = player.gridX + 1;
        int locationZ = player.gridZ;
        if (locationX <= 5)
        {
            if (bc.GetTile(locationX, locationZ).hasEnemy)
            {
                bc.tiles[locationX, locationZ].enemy.GetComponent<ShockwaveEnemy>().Damage(damage);
            }
            if (locationZ + 1 <= 2 && bc.GetTile(locationX, locationZ + 1).hasEnemy)
            {
                bc.tiles[locationX, locationZ].enemy.GetComponent<ShockwaveEnemy>().Damage(damage);
            }
            if (locationZ - 1 >= 0 && bc.GetTile(locationX, locationZ - 1).hasEnemy)
            {
                bc.tiles[locationX, locationZ].enemy.GetComponent<ShockwaveEnemy>().Damage(damage);
            }
            damage = 50;
        }
    }
}