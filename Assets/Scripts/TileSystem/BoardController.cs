using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public int tilesLong; //--x
    public int tilesWide; //--z

    public GameObject tilePrefab;

    public Tile[,] tiles;


    private void Start()
    {
        tiles = new Tile[tilesLong, tilesWide];

        for (int x = 0; x < tilesLong; x++)
        {
            for (int z = 0; z < tilesWide; z++)
            {
                GameObject go = Instantiate(tilePrefab, new Vector3(x, 0f, z), Quaternion.identity);
                go.transform.SetParent(transform);
                Tile t = go.GetComponent<Tile>();
                tiles[x, z] = t;
                t.Init(x, z);
                tiles[x, z].moveable = true;
                if (x > (tilesLong - 1) / 2)
                {
                    tiles[x, z].SetEnemyColor();
                    tiles[x, z].moveable = false;
                }
            }
        }
       
    }

    public Tile GetTile(int _x, int _z)
    {
        if (_x < 0 || _x > tilesLong - 1)
        {
            Debug.Log("Tile does not exist at " + _x.ToString() + " - " + _z.ToString());
            return null;
        }

        if (_z < 0 || _z > tilesWide - 1)
        {
            Debug.Log("Tile does not exist at " + _x.ToString() + " - " + _z.ToString());
            return null;
        }

        return tiles[_x, _z];
    }

    public Tile WorldToGrid(Vector3 _worldPos)
    {
        int x = Mathf.RoundToInt(_worldPos.x);
        int z = Mathf.RoundToInt(_worldPos.z);

        return GetTile(x, z);
    }

    public IEnumerator DeleteTile(Tile tile)
    {
        int x = tile.gridX;
        int z = tile.gridZ;
        Debug.Log("Delete Tile");
        tile.transform.position += Vector3.down * 5;
        tile.broken = true;
        yield return new WaitForSeconds(20f);
        Debug.Log("Recreate Tile");
        tile.transform.position += Vector3.up * 5;
        tile.broken = false;


    }

   
}
