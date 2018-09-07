using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour {

    public GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player(Clone)");
    }

    public GameObject getCurrentPlayer()
    {
        if (player == null)
            return player;
        else
            return GameObject.Find("Player(Clone)");
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        transform.Find("DieUI").gameObject.SetActive(false);
        player.GetComponent<PlayerStatusControl>().revive();
    }


	
	// Update is called once per frame
	void Update () {

        if (player == null)
            player = GameObject.Find("Player(Clone)").gameObject;

        //检查是否死亡
        if (player.GetComponent<PlayerStatusControl>().isDead())
        {
            transform.Find("DieUI").gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }


}
