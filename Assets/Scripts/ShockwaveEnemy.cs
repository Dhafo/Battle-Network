using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class ShockwaveEnemy : MonoBehaviour
{
    public int gridX;
    public int gridZ;

    [SerializeField]
    private Animator enemyAnim;

    public PlayerController player;
    public BoardController bc;

    float timer;

    bool attacking = false;

    bool moving = false;

    private int location;

    private int health;
    public TextMeshPro healthtext;


    // Update is called once per frame
    private void Start()
    {
        health = 60;
        gridX = (int)transform.position.x;
        gridZ = (int)transform.position.z;
        timer = 0;
        healthtext.text = health.ToString();
    }

    private void Update()
    {
        if (GameTime.isPaused) return;

        if(health == 0)
        {
            if (attacking)
            {
                location = gridZ;
                //from enemy location change the colors of each tile in the direction of the player ->
                for (int x = gridX; x >= 0; x--)
                {


                    if (bc.tiles[x, location].gameObject.AddComponent<ShockwaveTile>())
                    {

                        if(bc.tiles[x, location].moveable)
                        {
                            bc.tiles[x, location].SetNormalColor();
                        }
                        else
                        {
                            bc.tiles[x, location].SetEnemyColor();
                        }
                       
                            Destroy(bc.tiles[x, location].gameObject.GetComponent<ShockwaveTile>());
                       

                    }
                    else
                    {
                        continue;
                    }
                }

            }

            bc.tiles[gridX, gridZ].enemy = null;
            bc.tiles[gridX, gridZ].hasEnemy = false;
            Destroy(gameObject);
        }

        timer += GameTime.deltaTime;
        timer *= Random.Range(.9f, 1.1f);

        if (timer > Random.Range(1.6f, 4f) && !attacking)
        {
            if(player.gridZ != gridZ)
            {
                Move();
                timer = 0;
            }
            
        }

        if(player.gridZ == gridZ)
        {
            if (timer > Random.Range(1.6f, 4f))
            {
                enemyAnim.Play("GobAttack");  
                StartCoroutine(Shockwave());
                
                timer = 0;
            }
        }
        
        
    }

    private void Move()
    {
        if (!attacking)
        {
            moving = true;
            if (player.gridZ < gridZ)
            {
                if(!(bc.tiles[gridX, gridZ - 1].moveable) && !bc.tiles[gridX, gridZ - 1].broken)
                {
                    transform.position += Vector3.back;
                    gridZ = (int)transform.position.z;
                }
                


            }
            else if (player.gridZ > gridZ)
            {
                if (!(bc.tiles[gridX, gridZ + 1].moveable) && !bc.tiles[gridX, gridZ + 1].broken)
                {
                    transform.position += Vector3.forward;
                    gridZ = (int)transform.position.z;
                }
            }
        }
        moving = false;
    }

    IEnumerator Shockwave()
    {
        if (!moving)
        {
            //start attacking
            attacking = true;
            location = gridZ;
            //from enemy location change the colors of each tile in the direction of the player ->
            for (int x = gridX; x >= 0; x--)
            {
                if(bc.tiles[x, location].broken)
                {
                    break;
                }

                if (bc.tiles[x, location] != null)
                {
                    bc.tiles[x, location].SetHighlight();
                    bc.tiles[x, location].gameObject.AddComponent<ShockwaveTile>();
                   
                }
                else
                {
                    continue;
                }

                while (GameTime.isPaused == true)
                {
                    yield return new WaitForSeconds(0.2f);
                }
                //this is why it glitches?
                yield return new WaitForSeconds(.5f);



                //after a short time change the color back to the original tile color
                if (bc.tiles[x, location].moveable)
                {
                    bc.tiles[x, location].SetNormalColor();
                    Destroy(bc.tiles[x, location].gameObject.GetComponent<ShockwaveTile>());
                }
                else
                {
                    bc.tiles[x, location].SetEnemyColor();
                    Destroy(bc.tiles[x, location].gameObject.GetComponent<ShockwaveTile>());
                }
            }
        }
    
        //finished attacking
        attacking = false;
    }

    public void Damage(int damage)
    {
        health -= damage;
        if(health < 0)
        {
            health = 0;
        }
        healthtext.text = health.ToString();
    }

}
