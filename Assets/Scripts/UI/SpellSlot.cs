using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellSlot : MonoBehaviour
{
    public Spell spell;
    public int slotnum;
    private Image img;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    private void Update()
    {
        if (spell != null)
        {
            img.sprite = spell.artwork;
        }
        if(spell == null)
        {
            img.sprite = null;
        }
    }
  

}
