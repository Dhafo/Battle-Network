using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int gridX;
    public int gridZ;
    public Vector3 worldPosition;
    public bool moveable = true;
    public bool broken = false;

    private MeshRenderer myRend;
    private Color normalColor;
    public Color highlightedColor;
    public Color enemyColor;

    public bool hasPlayer = false;
    public bool hasEnemy = false;

    public GameObject enemy;
    


    public void Init(int _x, int _z)
    {
        gridX = _x;
        gridZ = _z;

        worldPosition = transform.position;

        myRend = GetComponent<MeshRenderer>();
        normalColor = myRend.material.color;

    }

    public void SetHighlight()
    {
        myRend.material.color = highlightedColor;
    }

    public void SetNormalColor()
    {
        myRend.material.color = normalColor;
    }

    public void SetEnemyColor()
    {
        myRend.material.color = enemyColor;
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.other.tag == "Player")
        {
            hasPlayer = true;
        }

        if(collision.other.tag == "Enemy")
        {
            enemy = collision.gameObject;
            hasEnemy = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.other.tag == "Player")
        {
            hasPlayer = false;
        }
        if(collision.other.tag == "Enemy")
        {
            hasEnemy = false;
        }
    }


}
