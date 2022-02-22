using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnim;
    [SerializeField]
    private TextMeshPro healthtext;
    public int gridX;
    public int gridZ;

    [SerializeField]
    float moveSpeed = 0.25f;
    Vector3 targetPosition;
    bool moving;

    public BoardController bc;

    public int health;
    public int maxhealth = 100;


    private bool damaged = false;
    private float damagetime = 0;

    private bool healing = false;
    private void Start()
    {
        health = maxhealth;
        healthtext.text = health.ToString();
        gridX = (int)transform.position.x;
        gridZ = (int)transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameTime.isPaused) return;

        if (health == 0)
        {
            Destroy(gameObject);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            BasicAttack();
        }

        if (Input.GetButtonDown("Up") && (gridZ + 1 <= 2) && bc.tiles[gridX, gridZ + 1].moveable && !bc.tiles[gridX, gridZ + 1].broken)
        {
            transform.position += Vector3.forward;
            gridZ += 1;
            moving = true;
        }

        if (Input.GetButtonDown("Down") && (gridZ - 1 >= 0) && bc.tiles[gridX, gridZ - 1].moveable && !bc.tiles[gridX, gridZ - 1].broken)
        {
            transform.position += Vector3.back;
            gridZ -= 1;
            moving = true;
        }

        if (Input.GetButtonDown("Right") && (gridX + 1 <= 5) && bc.tiles[gridX + 1, gridZ].moveable && !bc.tiles[gridX + 1, gridZ].broken)
        {
            transform.position += Vector3.right;
            gridX += 1;
            moving = true;
        }

        if (Input.GetButtonDown("Left") && (gridX - 1 >= 0) && bc.tiles[gridX - 1, gridZ].moveable && !bc.tiles[gridX - 1, gridZ].broken)
        {
            transform.position += Vector3.left;
            gridX -= 1;
            moving = true;
        }
        moving = false;

        // DAMAGE MECHANICS
        if (damaged)
        {
            damagetime += Time.deltaTime;
        }

        if (damagetime > 1.4f)
        {
            damaged = false;
            damagetime = 0;
        }

        // HEALTH/DEATH
        if (health == 0)
        {
            Debug.Log("You died");
        }

    }

    public void DamagePlayer(int damage)
    {
        if (!damaged)
        {
            health -= damage;
            if (health < 0)
            {
                health = 0;
            }
            healthtext.text = health.ToString();
            damaged = true;
        }
    }

    public void BasicAttack()
    {
        if (this.playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            int location = gridZ;
            playerAnim.Play("Attack");
            for (int x = gridX; x <= 5; x++)
            {
                if (bc.tiles[x, location].hasEnemy)
                {
                    bc.tiles[x, location].enemy.GetComponent<ShockwaveEnemy>().Damage(1);
                    break;
                }
            }
        }
    }

    public void HealPlayer(int amount)
    {
        if (!healing)
        {
            health += amount;
            if (health > maxhealth)
            {
                health = maxhealth;
            }
            healthtext.text = health.ToString();
            damaged = true;
        }
    }

}
