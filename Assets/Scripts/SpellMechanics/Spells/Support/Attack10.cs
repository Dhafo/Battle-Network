using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Support/Attack10")]
public class Attack10 : Spell
{

    public override void CastSpell(PlayerController player, BoardController bc)
    {
        SpellBar sb = GameObject.FindGameObjectWithTag("SB").GetComponent<SpellBar>();
        sb.slots[1].spell.damage += 10;
    }
}
