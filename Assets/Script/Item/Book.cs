using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour {


    public Sprite bookClose;
    public Sprite bookOpen;

    private bool IsOpen;

    public void interact(GameObject other)
    {
        this.GetComponent<SpriteRenderer>().sprite = bookOpen;
    }

	// Use this for initialization
	void Start () {
        IsOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
