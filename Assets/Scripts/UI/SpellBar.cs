using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBar : MonoBehaviour
{
    public bool[] isFull;
    public List<SpellSlot> slots;


    public void RemoveItem()
    {
        for (int x = 0; x <= 4; x++)
        {
            if (x != 4)
            {
                slots[x].spell = slots[x + 1].spell;
            }
            else
            {
                slots[x].spell = null;
            }

        }

    }
}
