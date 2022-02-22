
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Ranged/VGun")]
public class VGun : Spell
{
    public override void CastSpell(PlayerController player, BoardController bc)
    {
        int location = player.gridZ;

        for (int x = player.gridX; x <= 5; x++)
        {
            if (bc.tiles[x, location].hasEnemy)
            {
                bc.tiles[x, location].enemy.GetComponent<ShockwaveEnemy>().Damage(damage);
                if ((x + 1) <= 5 && (location - 1) >= 0)
                {
                    if(bc.tiles[x + 1, location].hasEnemy)
                    {
                        bc.tiles[x + 1, location + 1].enemy.GetComponent<ShockwaveEnemy>().Damage(damage);
                    }
                    
                }
                if ((x + 1) <= 5 && (location - 1) >= 0)
                {
                    if(bc.tiles[x + 1, location].hasEnemy)
                    {
                        bc.tiles[x + 1, location - 1].enemy.GetComponent<ShockwaveEnemy>().Damage(damage);
                    }
                    
                }
                break;
            }
        }
        damage = 30;

    }
}