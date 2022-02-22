
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Ranged/Airshot")]
public class Airshot : Spell
{
    public override void CastSpell(PlayerController player, BoardController bc)
    {
        int location = player.gridZ;

        for (int x = player.gridX; x <= 5; x++)
        {
            if (bc.tiles[x, location].hasEnemy)
            {
                bc.tiles[x, location].enemy.GetComponent<ShockwaveEnemy>().Damage(damage);

                if((x + 1) <= 5 && bc.tiles[x + 1, location].hasEnemy == false)
                {
                    bc.tiles[x, location].enemy.transform.position += Vector3.right;
                }

                break;
            }

        }
        damage = 20;

    }
}