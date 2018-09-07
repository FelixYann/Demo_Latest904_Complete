using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 物体的个性定制部分
/// 为interaction.cs提供物体交互方法interact()
/// </summary>

public class Can : MonoBehaviour {

	public Sprite can_up;
	public Sprite can_down;
	public bool hasItem;

    private bool is_up;

    // Use this for initialization
    void Start () {
		is_up = true;
	}
	
    public void interact(GameObject player)
    {
        this.GetComponent<SpriteRenderer>().sprite = can_down;
        if (hasItem)
        {
            SendMessage("popItem");            
        }
        hasItem = false;
    }



}
