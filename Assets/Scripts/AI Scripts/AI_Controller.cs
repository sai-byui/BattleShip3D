using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Controller : MonoBehaviour {

    AIBase AI;
    public GameObject[] ShipPrefabs;

	// Use this for initialization
	void Start () {
        AI = new AIBase();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Placeships(){
        AI.ships.Add(new Ship(5));
        AI.ships.Add(new Ship(4));
        AI.ships.Add(new Ship(3));
        AI.ships.Add(new Ship(3));
        AI.ships.Add(new Ship(2));
        int x, y;
        bool vert, direction;
        for (int s = 0; s < AI.ships.Count; s++)
        {
            // Place ship 's'
            x = Random.Range(0, GameController.BOARDX);
            y = Random.Range(0, GameController.BOARDY);

            vert = Random.Range(0,2) == 0;
            direction = Random.Range(0, 2) == 0;
            int i, j;
            i = x;
            j = y;
            bool valid = true;
            for (int k = 0; k < AI.ships[s].GetSize(); k++)
            {
                print("Getting tile: " + new Vector2(i, j).ToString());
                if (i >= GameController.BOARDX || j >= GameController.BOARDY || i < 0 || j < 0
                    || GameController.GetTile(new Vector2(i, j), 1).GetState() != Tile_State.EMPTY)
                {
                    valid = false;
                    break;
                }
                if (vert)
                {
                    if (direction) j++;
                    else j--;
                }
                else
                {
                    if (direction) i++;
                    else i--;
                }
            }
            if (!valid)
            { // decrement s so that we try the loop again.
                s--;
                continue;
            }
            // Place ship on screen
            //float rotation = (vert ? 0 : 90);
            //rotation += (direction ? 0 : 90);
            float rotation = 0f;
            if (vert && !direction)
                rotation = 180f;
            else if (!vert && direction)
                rotation = -90f;
            else if (!vert && !direction)
                rotation = 90f;

            GameController.SpawnShip(new Vector2(x, y), AI.ships[s].GetSize(), rotation);
            // Ship must be valid so now we can place it
            for (int k = 0; k < AI.ships[s].GetSize(); k++)
            {
                //print("Getting tile: " + new Vector2(x, y).ToString());
                GameController.GetTile(new Vector2(x, y), 1).SetState(Tile_State.SHIP);
                AI.ships[s].AddLocation(new Vector2(x, y));
                if (vert)
                {
                    if (direction) y++;
                    else y--;
                }
                else
                {
                    if (direction) x++;
                    else x--;
                }
            }
        }
    }
}