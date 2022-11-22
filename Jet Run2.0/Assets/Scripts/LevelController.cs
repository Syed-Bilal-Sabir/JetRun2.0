using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject[] tiles;
    public float zspawn=0;
    public float tilelength = 30;
    public int numberoftiles=5;
    public Transform playerTransform;
    private List<GameObject> activeTile=new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberoftiles; i++)
        {
            if (i == 0)
            {
                spawnTile(0);
            }
            else
            {
                spawnTile(Random.Range(0,tiles.Length));
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z -35 > zspawn-(numberoftiles*tilelength))
        {
            spawnTile(Random.Range(0, tiles.Length));
            Deletetile();
        }
    }
    public void spawnTile(int tileindex) {
        GameObject go =Instantiate(tiles[tileindex],transform.forward*zspawn,transform.rotation);
        activeTile.Add(go);
        zspawn+=tilelength;
    
    }
    private void Deletetile()
    {
        Destroy(activeTile[0]);
        activeTile.RemoveAt(0);

    }
}
