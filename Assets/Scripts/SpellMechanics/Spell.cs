using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Default" )]
public class Spell : ScriptableObject
{
    public string spellname;
    public string description;
    public Sprite artwork;
    public int damage;
    public string spellschool;
  

    public virtual void CastSpell(PlayerController player, BoardController bc)
    {
        Debug.Log("Default Cast");
    }
    //spell function?????????
}
