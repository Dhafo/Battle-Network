using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Support/Steal")]
public class Steal : Spell
{

    public override void CastSpell(PlayerController player, BoardController bc)
    {
        int location = player.gridX + 1;
        int locZ = player.gridZ;
        for (int x = location; x <= 5; location++)
        {
            if (location > 5)
            {
                break;
            }
            if (!(bc.tiles[location, locZ].moveable))
            {
                for (int z = 0; z <= 2; z++)
                {
                    if (!(bc.tiles[location, z].hasEnemy))
                    {
                        bc.tiles[location, z].moveable = true;
                        bc.tiles[location, z].SetNormalColor();
                    }
                }
                break;
            }
            else
            {
                continue;
            }
        }
    }
}
