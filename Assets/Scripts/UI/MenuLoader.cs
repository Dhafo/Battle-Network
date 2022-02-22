using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuLoader : MonoBehaviour
{
    public List<Spell> spells;
    public List<MenuSlot> slots;
    public List<MenuSlot> slots2;
    public MenuAppearScript menu;
    // Update is called once per frame

    private void Start()
    {
        for (int x = 0; x <= 4; x++)
        {
            slots[x].spell = null;
        }

        menu.rando = true;

        for (int x = 0; x <= 4; x++)
        {
            slots2[x].spell = null;
        }
    }

    void Update()
    {
        if (menu.rando)
        {
            for (int x = 0; x <= 4; x++)
            {
                if(slots[x].spell == null)
                {
                    slots[x].spell = spells[Random.Range(0, spells.Count)];
                    slots[x].menuindex = x;
                }
                    
            }
            menu.rando = false;    
        }
    }        
    

    public void AddSpells()
    {
        for (int x = 0; x <= 4; x++)
        {
            slots2[x].spell = spells[Random.Range(0, spells.Count)];
            slots2[x].menuindex += x + 5;
        }
    }
}
