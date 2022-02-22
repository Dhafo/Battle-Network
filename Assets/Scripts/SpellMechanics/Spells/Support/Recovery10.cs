using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Support/Recovery10")]
public class Recovery10 : Spell
{

    public override void CastSpell(PlayerController player, BoardController bc)
    {
        player.HealPlayer(10);
    }
}
