using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R11x11: RoomTemplate{
    //private void Start()
    //{
    //    InitList();
    //}

    public void InitList()
    {
        N1();
        N2();
        
    }
    void N1()
    {
        List<ItemAndPos> temp = new List<ItemAndPos>();
        temp.Add(new ItemAndPos(ItemType.Barrier22, 2, 7));
        temp.Add(new ItemAndPos(ItemType.Barrier22, 7, 7));
        temp.Add(new ItemAndPos(ItemType.Monster, 4, 6));
        temp.Add(new ItemAndPos(ItemType.Monster, 6, 6));
        temp.Add(new ItemAndPos(ItemType.Chest11, 5, 5));
        temp.Add(new ItemAndPos(ItemType.Monster, 4, 4));
        temp.Add(new ItemAndPos(ItemType.Monster, 6, 4));
        temp.Add(new ItemAndPos(ItemType.Barrier22, 2, 2));
        temp.Add(new ItemAndPos(ItemType.Barrier22, 7, 2));
        ItemList.Add(temp);
    }

    void N2()
    {
        List<ItemAndPos> temp = new List<ItemAndPos>();
        temp.Add(new ItemAndPos(ItemType.Barrier31, 2, 8));
        temp.Add(new ItemAndPos(ItemType.Barrier31, 6, 6));
        temp.Add(new ItemAndPos(ItemType.Barrier31, 2, 4));
        temp.Add(new ItemAndPos(ItemType.Barrier31, 6, 2));
        temp.Add(new ItemAndPos(ItemType.Terrain22, 5, 7));
        temp.Add(new ItemAndPos(ItemType.Terrain22, 5, 4));
        temp.Add(new ItemAndPos(ItemType.Terrain11, 3, 2));
        temp.Add(new ItemAndPos(ItemType.Monster, 3, 5));
        temp.Add(new ItemAndPos(ItemType.Monster, 4, 6));
        temp.Add(new ItemAndPos(ItemType.Monster, 7, 5));
        ItemList.Add(temp);
    }


}
