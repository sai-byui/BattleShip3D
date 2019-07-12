using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBase{

    public List<Ship> ships = new List<Ship>();
    int shipsSunk = 0;

    public bool DidSink()
    {
        int actualSunk = 0;
        for (int i = 0; i < ships.Count; i++)
        {
            if (ships[i].IsSunk()) actualSunk++;
        }
        //if (actualSunk > 0) return true;
        if (actualSunk > shipsSunk)
        {
            shipsSunk = actualSunk;
            return true;
        }
        return false;
    }

    public bool CheckForHit(Vector2 location)
    {
        Tile target = GameController.GetTile(location);
        switch (target.GetState())
        {
            case Tile_State.MISS:
            case Tile_State.HIT:
            case Tile_State.EMPTY:
                //cout << "\nMiss!\n";
                GameController.SetMessage("Miss!");
                target.SetState(Tile_State.MISS);
                break;

            case Tile_State.SHIP:
                //cout << "\nHit!\n";
                GameController.SetMessage("Hit!");
                target.SetState(Tile_State.HIT);
                return true;
        }
        return false;
    }

    bool ShipsLeft()
    {
        for (int i = 0; i < ships.Count; i++){
            if (!ships[i].IsSunk()){
                return true;
            }
        }
        return false;
    }
}
