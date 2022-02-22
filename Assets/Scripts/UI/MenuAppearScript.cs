using UnityEngine;
using System.Collections;

public class MenuAppearScript : MonoBehaviour
{
    public ManaBarController mana;
    public GameObject menu;
    public Animator anim;
    private SpellDisplay display;
    private bool isShowing = false;
    public bool rando = false;
    float timer;

    private void Start()
    {
        timer = 0;
        display = GameObject.FindGameObjectWithTag("Display").GetComponent<SpellDisplay>();
        isShowing = true;
        rando = true;
        GameTime.isPaused = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && mana.filled)
        {
            isShowing = true;
            rando = true;
            GameTime.isPaused = true;
        }


        if (isShowing)
        {
            
            anim.SetBool("Showing", true);
            menu.SetActive(isShowing);
            mana.SpendMana(100);
            

        }
        else
        {
            anim.SetBool("Showing", false);
            timer += Time.deltaTime;
            GameTime.isPaused = false;

        }
        

        if(timer > 1.4f)
        {
            menu.SetActive(isShowing);
            timer = 0;
            mana.filled = false;
        }
    }

    public void SetShowing()
    {
        isShowing = false;
    }
}