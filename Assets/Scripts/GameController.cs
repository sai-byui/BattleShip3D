using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject tile;
    Dictionary<Vector2, Tile> p1Map = new Dictionary<Vector2, Tile>();
    Dictionary<Vector2, Tile> p2Map = new Dictionary<Vector2, Tile>();

	// Use this for initialization
	void Start () {
        float buffer = 0f;
        for (int i = -3; i < 5; i++){
            for (int j = -3; j < 5; j++){
                Tile t1 = Instantiate(tile, new Vector3(i - 5.5f - buffer, j - .5f, 0), Quaternion.identity).GetComponent<Tile>();
                p1Map.Add(new Vector2(i + 3, j + 3), t1);
                t1.SetGridCoords(new Vector2(i + 3, j + 3));
                Tile t2 = Instantiate(tile, new Vector3(i + 4.5f - buffer, j - .5f, 0), Quaternion.identity).GetComponent<Tile>();
                p2Map.Add(new Vector2(i + 3, j + 3), t2);
                t2.SetGridCoords(new Vector2(i + 3, j + 3));
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
