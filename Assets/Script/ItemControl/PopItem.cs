using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopItem : MonoBehaviour {

    public GameObject Item;

    public void popItem()
    {
        GameObject item = Instantiate(Item, transform.position, transform.rotation);
        item.GetComponent<Rigidbody2D>().AddForce(new Vector2(100,0));
    }

}
