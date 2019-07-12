using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship {

    List<Vector2> locations = new List<Vector2>();
    int size;

    public Ship(List<Vector2> vectors){
        locations = vectors;
    }
    public Ship(int size){
        this.size = size;
    }

    public void AddLocation(Vector2 location){
        locations.Add(location);
    }
    public bool IsSunk(){
        for (int i = 0; i < locations.Count; i++){
            if (GameController.GetTile(locations[i]).GetState() != Tile_State.HIT){
                return false;
            }
        }
        return true;
    }
    public int GetSize(){
        return size;
    }

}
