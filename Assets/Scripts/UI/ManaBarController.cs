using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarController : MonoBehaviour
{
    private Mana mana;
    private Image barImage;
    public bool filled;


    private void Awake()
    {
        barImage = transform.Find("bar").GetComponent<Image>();

        mana = new Mana();
    }

    private void Update()
    {
        mana.Update();

        barImage.fillAmount = mana.GetManaNormalized();

        if (barImage.fillAmount == 1)
        {
            filled = true;
        }
    }

    public void SpendMana(int amount)
    {
        mana.SpendMana(amount);
    }
}

    public class Mana
    {
        public const int MANA_MAX = 100;
        private ManaBarController manaBarController;
        private float manaAmount;
        private float manaRegenAmount;


        public Mana()
        {
            manaAmount = 0;
            manaRegenAmount = 12f;
            manaBarController = GameObject.FindGameObjectWithTag("bar").GetComponent<ManaBarController>();
        }

        public void Update()
        {
        if (!manaBarController.filled)
        {
            manaAmount += manaRegenAmount * Time.deltaTime;
        }
        }
           
        public void SpendMana(int amount)
        {
            if (manaAmount >= amount)
            {
                manaAmount -= amount;
            }
        }

        public float GetManaNormalized()
        {
            return manaAmount / MANA_MAX;
        }

    }
