using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Melee/SwordSlash")]
public class SwordAttack : Spell
{

    public override void CastSpell(PlayerController player, BoardController bc)
    {
        
        int locationX = player.gridX + 1;
        int locationZ = player.gridZ;
        Debug.Log("Sword Slash towards " + locationX.ToString() + " - " + (locationZ).ToString());
        if(bc.GetTile(locationX, locationZ).hasEnemy)
        {
            Debug.Log("Sword Slash Hit");
            bc.tiles[locationX, locationZ].enemy.GetComponent<ShockwaveEnemy>().Damage(damage);
        }
        damage = 50;
    }
}
