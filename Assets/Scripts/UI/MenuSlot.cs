using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Net;

public class MenuSlot : EventTrigger
{
    public Spell spell;
    private Image img;
    private SpellDisplay display;
    public bool showing = false;
    public int menuindex;
    private void Start()
    {
        img = GetComponent<Image>();
        display = GameObject.FindGameObjectWithTag("Display").GetComponent<SpellDisplay>();
    }

    private void Update()
    {
       
        if (showing)
        {
            if(spell != null)
            {
                img.sprite = spell.artwork;
            }
          
        }
        else
        {
            img.sprite = null;
        }
        

    }


    //Do this when the selectable UI object is selected.
    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);
        if (showing) 
        {
            display.currentspell = spell;
        }
       
    }

    public override void OnSubmit(BaseEventData eventData)
    {
        if(display.slots[4].spell == null)
        {
            if (showing)
            {
                if(display.slots[0].spell == null)
                {
                    base.OnSubmit(eventData);
                    Debug.Log(spell.name.ToString());
                    showing = false;
                    display.InsertSpell(spell, menuindex);
                }
                else if(spell.spellschool == display.slots[0].spell.spellschool || spell.spellname == display.slots[0].spell.spellname || spell.spellschool == "*" || display.slots[0].spell.spellschool == "*")
                {
                    base.OnSubmit(eventData);
                    Debug.Log(spell.name.ToString());
                    showing = false;
                    display.InsertSpell(spell, menuindex);
                }
                
            }
        }
        
    }
        

    public override void OnCancel(BaseEventData eventData)
    {
        base.OnCancel(eventData);
        display.RemoveSpell();

    }


}
