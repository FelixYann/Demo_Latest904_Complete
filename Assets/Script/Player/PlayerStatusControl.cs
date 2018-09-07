using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//控制并存储角色的不同状态、属性

public class PlayerStatusControl : MonoBehaviour {

    public float damageTime = 0.5f; //角色收到攻击的时间间隔
    public int MaxHP = 10; //最大HP
    public int InitHP = 10; //初始HP
    public int HP = 0; //当前HP

    public int MaxAmmo = 500; //最大弹药量
    public int InitAmmo = 100;
    public int ammo = 0; //当前弹药量

    private bool IsHidden = false; //是否为隐藏状态
    private bool IsDead = false; //是否死亡
    private bool IsHit = false; //是否为被击中状态


    private float flashTimer; 
    private SpriteRenderer spriteRender;

    //返回是否为隐藏状态
    public bool isHidden()
    {
        return IsHidden;
    }

    //返回角色是否死亡
    public bool isDead()
    {
        return IsDead;
    }

    //返回角色是否是被击中状态
    public bool isHit()
    {
        return IsHit;
    }

    //返回角色当前HP
    public int getCurrentHP()
    {
        return HP;
    }

    //角色进入隐藏状态
    public void hidePlayer()
    {
        IsHidden = true;
        spriteRender.enabled = false;
    }

    //角色退出隐藏状态
    public void showPlayer()
    {
        IsHidden = false;
        spriteRender.enabled = true;
    }

    //对角色造成伤害
    public void damagePlayer(int amount)
    {
        if (IsHit == false)
        {
            IsHit = true;
            HP -= amount;
            //死否死亡
            if (HP <= 0)
            {
                IsDead = true;
                //SendMessage("PlayerDie");
            }
        }
    }

    //复活
    public void revive()
    {
        HP = MaxHP;
        IsDead = false;
    }

    //角色增加弹药
    public void addAmmo(int amount)
    {
        ammo += amount;
        if (ammo >= MaxAmmo)
        {
            ammo = MaxAmmo;
        }
    }

    //角色消耗弹药
    public bool consumeAmmo(int amount)
    {
        if (ammo >= amount)
        {
            ammo -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    //返回当前弹药量
    public int getCurrentAmmo()
    {
        return ammo;
    }

    // Use this for initialization
    void Start () {
        HP = InitHP;
        ammo = InitAmmo;
        IsDead = false;
        flashTimer = damageTime;
        spriteRender = this.gameObject.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

        //击中效果
        if (IsHit)
        {
            flashTimer -= Time.deltaTime;

            if (flashTimer > damageTime - 0.1f)
            {
                spriteRender.color = new Color(0.9f, 0.5f, 0.5f, 1f);
                Debug.Log("Player.cs: Player Hit");
            }
            else if (flashTimer > 0 && flashTimer <= damageTime - 0.1f)
            {
                spriteRender.color = new Color(1f, 1f, 1f, 1f);
            }
            else if (flashTimer < 0)
            {
                IsHit = false;
                flashTimer = damageTime;
            }

        }


    }


}
