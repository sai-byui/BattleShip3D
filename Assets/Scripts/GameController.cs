using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static readonly int BOARDX = 8;
    public static readonly int BOARDY = 8;

    // These are set in the inspector
    public GameObject tile;
    public GameObject rb, lb;
    public GameObject explosion;
    public Text displayMessage;
    public AI_Controller player1;
    public GameObject[] ships;
    public GameObject hitPrefab;
    public GameObject missPrefab;

    private static GameController instance;

    Dictionary<Vector2, Tile> p1Map = new Dictionary<Vector2, Tile>();
    Dictionary<Vector2, Tile> p2Map = new Dictionary<Vector2, Tile>();

	// Use this for initialization
	void Start () {
        instance = this;
        float size = tile.transform.localScale.x;// Assuming this is a square, either x or y will work
        float centerBuffer = 6f;
        //print(size.ToString());
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
        player1.Placeships();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void SetMessage(string message){
        instance.displayMessage.text = message;
    }

    public static Tile GetTile(Vector2 location, int mapNum=2){
        if (mapNum == 1){
            return instance.p1Map[location];
        }
        else{
            return instance.p2Map[location];
        }
    }

    public static void Explode(Vector2 location){
        Instantiate(instance.explosion, location, Quaternion.identity);
    }

    public static void SpawnShip(Vector2 location, int size, float rotation){
        Vector3 loc = GetTile(location, 1).transform.position;
        GameObject ship = Instantiate(instance.ships[size - 2], loc, Quaternion.Euler(0f,0f, rotation));
        ship.transform.position = ship.transform.position - (ship.transform.up/2);
        print(ship.transform.right);
    }
}
