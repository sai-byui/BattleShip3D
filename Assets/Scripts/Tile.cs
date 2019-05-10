using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    bool selected = false;
    public Vector2 gridCoords;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
}
