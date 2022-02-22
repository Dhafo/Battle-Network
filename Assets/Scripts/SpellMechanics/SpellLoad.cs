using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellLoad : MonoBehaviour
{
    public List<Spell> spells;
    public List<SpellSlot> slots;
    public List<SpellSlot> spelllist;

    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {

        for(i = 0; i <= 4; i++)
        {
            slots[i].spell = spells[i];
        }

    }

    public void LoadSpells()
    {
        for(int x = 0; x <= 4; x++)
        {
            slots[x].spell = spelllist[x].spell;
        }
    }
}

