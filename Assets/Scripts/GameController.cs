using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject tile;
    public GameObject rb, lb;
    Dictionary<Vector2, Tile> p1Map = new Dictionary<Vector2, Tile>();
    Dictionary<Vector2, Tile> p2Map = new Dictionary<Vector2, Tile>();

	// Use this for initialization
	void Start () {
        float size = tile.transform.localScale.x;// Assuming this is a square, either x or y will work
        float centerBuffer = 6f;
        print(size.ToString());
        for (int i = -3; i < 5; i++){
            for (int j = -3; j < 5; j++){
                Tile t1 = Instantiate(tile, new Vector3(j*size - centerBuffer, i*size - .5f, 0), Quaternion.identity, lb.transform).GetComponent<Tile>();
                p1Map.Add(new Vector2(j + 3, i + 3), t1);
                t1.SetGridCoords(new Vector2(j + 3, i + 3));
                Tile t2 = Instantiate(tile, new Vector3(j*size + centerBuffer - size, i*size - .5f, 0), Quaternion.identity, rb.transform).GetComponent<Tile>();
                p2Map.Add(new Vector2(j + 3, i + 3), t2);
                t2.SetGridCoords(new Vector2(j + 3, i + 3));
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
