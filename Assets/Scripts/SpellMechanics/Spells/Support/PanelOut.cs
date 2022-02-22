using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Support/PanelOut")]
public class PanelOut : Spell
{

    public override void CastSpell(PlayerController player, BoardController bc)
    {
        int location = player.gridX + 1;
        int locZ = player.gridZ;
        if(location <= 5 && !bc.tiles[location, locZ].hasEnemy)
        {
           bc.StartCoroutine(bc.DeleteTile(bc.tiles[location, locZ]));
        }
    }
}
