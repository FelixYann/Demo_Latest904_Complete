using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制敌人的HP状态
/// 需要对敌人造成伤害时调用damage(int)方法
/// 每当造成伤害会尝试调用敌人上的ItemOnHit()方法
/// 物体HP耗尽时会尝试调用敌人上的Die()方法
/// </summary>


public class EnemyStatusControl : MonoBehaviour {

    public int MaxHP = 4;
    public int damageAmount = 1;

    private int HP;
    private bool IsDead = false;

    public int getCurrentHP()
    {
        return HP;
    }

    public int getMaxHP()
    {
        return MaxHP;
    }

    public bool isDead()
    {
        return IsDead;
    }

    virtual public void damageItem(int d)
    {
        HP -= d;
        SendMessage("EnemyOnHit");
        if (HP <= 0)
        {
            IsDead = true;
            SendMessage("EnemyDie");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<PlayerStatusControl>().damagePlayer(damageAmount);
        }
    }

    // Use this for initialization
    void Start () {
        HP = MaxHP;
	}


}
