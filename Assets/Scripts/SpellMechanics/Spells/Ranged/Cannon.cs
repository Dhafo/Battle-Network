
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Ranged/Cannon")]
public class Cannon : Spell
{

    public override void CastSpell(PlayerController player, BoardController bc)
    {
        int location = player.gridZ;
     
                for (int x = player.gridX; x <= 5; x++)
                {
                    if (bc.tiles[x, location].hasEnemy)
                    {
                        bc.tiles[x, location].enemy.GetComponent<ShockwaveEnemy>().Damage(damage);
                        break;
                    }
                     
                }
                damage = 40;

    }
}
