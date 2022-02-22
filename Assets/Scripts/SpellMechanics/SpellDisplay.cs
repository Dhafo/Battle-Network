using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SpellDisplay : MonoBehaviour
{
    public Spell currentspell;
    public List<SpellSlot> slots;
    public List<MenuSlot> menuslots;
    public List<int> menuorigins;

    // Start is called before the first frame update
    void Update()
    {
        Text[] com = gameObject.GetComponentsInChildren<Text>();
        if(currentspell != null)
        {
        com[0].text = currentspell.spellname;
        com[1].text = currentspell.description;
        com[2].text = currentspell.spellschool;
        gameObject.GetComponentInChildren<Image>().sprite = currentspell.artwork;
        }

    }

    public void InsertSpell(Spell spell, int menuindex)
    {
        for (int x = 0; x <= 4; x++)
        {
            if (slots[x].spell != null)
            {
                continue;
            }
            else
            {
                slots[x].spell = spell;
                menuorigins[x] = menuindex;
                break;
            }
            
        }
    }

    public void RemoveSpell()
    {
        for (int x = 4; x >= 0; x--)
        {
            if (slots[x].spell != null)
            {
                Debug.Log(x.ToString() + "not equal to null");
                slots[x].spell = null;
                for (int y = 0; y <= 14; y++)
                { 
                    if(menuslots[y].menuindex == menuorigins[x])
                    {
                        menuslots[y].showing = true;
                    } 
                }
                break;
            }
            else
            {
                Debug.Log(x.ToString()+ "equal to null");
                continue;
            }
        }
    }

    public void ClearQueue()
    {
        for(int x = 4; x >= 0; x--)
        {
            if (slots[x].spell != null)
            {
                slots[x].spell = null;
                for (int y = 0; y <= 9; y++)
                {
                    if (menuslots[y].menuindex == menuorigins[x])
                    {
                        menuslots[y].spell = null;
                        menuslots[y].showing = true;
                    }
                }
            }
            
        }

    }

}
