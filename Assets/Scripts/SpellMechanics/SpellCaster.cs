using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCaster : MonoBehaviour
{
    public SpellSlot slot;
    public PlayerController player;
    private BoardController bc;
    private SpellBar sb;

    private void Start()
    {
        bc = GameObject.FindGameObjectWithTag("BC").GetComponent<BoardController>();
        sb = GameObject.FindGameObjectWithTag("SB").GetComponent<SpellBar>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            slot.spell.CastSpell(player, bc);
            sb.RemoveItem();
        }

    }
}
