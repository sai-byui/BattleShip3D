﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tile_State{ EMPTY, HIT, SHIP, MISS };

public class Tile : MonoBehaviour {

    bool selected = false;
    public Vector2 gridCoords;

    public Tile_State state = Tile_State.EMPTY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Click message
        if (Input.GetMouseButtonDown(0) && selected){
            print("Clicked tile: " + gridCoords.ToString());
            GameController.SetMessage("Clicked tile: " + gridCoords.ToString());
            GameController.Explode(transform.position);
        }
		
	}
    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = new Color(100, 100, 100);
        selected = true;
    }
    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
        selected = false;
    }

    public void SetGridCoords(Vector2 coords){
        gridCoords = coords;
    }

    public void SetState(Tile_State newState){
        state = newState;
        switch (state){
            case Tile_State.EMPTY:
                break;
            case Tile_State.HIT:
                break;
            case Tile_State.MISS:
                break;
            case Tile_State.SHIP:
                break;
        }
    }

}
