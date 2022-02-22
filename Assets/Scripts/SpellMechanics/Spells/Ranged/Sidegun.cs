
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Ranged/Sidegun")]
public class Sidegun : Spell
{
    public override void CastSpell(PlayerController player, BoardController bc)
    {
        int location = player.gridZ;

        for (int x = player.gridX; x <= 5; x++)
        {
            if (bc.tiles[x, location].hasEnemy)
            {
                bc.tiles[x, location].enemy.GetComponent<ShockwaveEnemy>().Damage(damage);
                
                if ((location + 1) <= 2 && bc.tiles[x, location + 1].hasEnemy)
                {
                    bc.tiles[x, location + 1].enemy.GetComponent<ShockwaveEnemy>().Damage(damage);
                }
                if ((location - 1) >= 0 && bc.tiles[x, location - 1].hasEnemy)
                {
                    bc.tiles[x, location - 1].enemy.GetComponent<ShockwaveEnemy>().Damage(damage);
                }
                break;
            }

        }
        damage = 30;

    }
}