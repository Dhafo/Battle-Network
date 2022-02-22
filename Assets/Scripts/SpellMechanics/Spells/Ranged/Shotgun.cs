
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Ranged/Shotgun")]
public class Shotgun : Spell
{
    public override void CastSpell(PlayerController player, BoardController bc)
    {
        int location = player.gridZ;

        for (int x = player.gridX; x <= 5; x++)
        {
            if (bc.tiles[x, location].hasEnemy)
            {
                bc.tiles[x, location].enemy.GetComponent<ShockwaveEnemy>().Damage(damage);
                if ((x + 1) <= 5 && bc.tiles[x + 1, location].hasEnemy)
                {
                    bc.tiles[x + 1, location].enemy.GetComponent<ShockwaveEnemy>().Damage(damage);
                }
                break;
            }
           
        }
        damage = 30;

    }
}