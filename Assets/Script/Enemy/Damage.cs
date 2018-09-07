using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 负责造成伤害
/// </summary>

public class Damage : MonoBehaviour {

    public int damageAmount;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<PlayerStatusControl>().damagePlayer(damageAmount);
        }
    }

}
