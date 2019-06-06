using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship {

    List<Vector2> locations = new List<Vector2>();

    Ship(List<Vector2> vectors){
        locations = vectors;
    }

    void AddLocation(Vector2 location){
        locations.Add(location);
    }
    public bool IsSunk(){
        for (int i = 0; i < locations.Count; i++){
            if (GameController.GetTile(locations[i]).state != Tile_State.HIT){
                return false;
            }
        }
        return true;
    }

}
