using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplate{

    public List<List<ItemAndPos>> ItemList = new List<List<ItemAndPos>>();

}


public class ItemAndPos
{
    public float x;
    public float y;
    public ItemType type;

    public ItemAndPos(ItemType t,float xx,float yy)
    {
        type = t;
        x = xx;
        y = yy;
    }
}
public enum ItemType
{
    Item11, Item21, Item22,
    Barrier11, Barrier21, Barrier22,Barrier31,
    Monster,
    Chest11,
    Terrain11, Terrain22, Terrain33,
}