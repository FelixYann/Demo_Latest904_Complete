using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制玩家与道具的互动
/// 为每一个道具添加该组件以及ButtonF子对象
/// 即可使玩家在接近道具时出现“F”提示
/// 与ItemDetector.cs配合
/// 
/// 为道具对象添加 interact(GameObject player)方法
/// 在该方法内完成道具的相应互动行为
/// </summary>

public class Interaction : MonoBehaviour {

    public bool PressToInteract = true; //按键互动开关
    public bool KnockedToInteract = false; //碰撞互动开关
    public bool AttackToInteract = false; //攻击互动开关
    public bool Repeat = false;
    public GameObject buttonF;

    private bool state;  //是否为可互动状态
    private bool IsActive;    //是否在角色控制范围内
    private GameObject Player;
    private GameObject btn;

    // Use this for initialization
    void Start () {
        state = true;
        IsActive = false;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(PressToInteract && state && collision.tag == "Detector")
        {
            btn = Instantiate(buttonF, this.transform);
            IsActive = true;
            Player = collision.transform.parent.gameObject;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //角色碰撞互动
        if (KnockedToInteract && state && collision.collider.tag == "Player")
        {

            Player = collision.collider.transform.gameObject;
            SendMessage("interact", Player);

            if (!Repeat)
            {
                Destroy(btn);
                state = false;
            }
        }

        //子弹攻击互动
        if (AttackToInteract && state && collision.collider.tag == "Bullet")
        {
            Debug.Log("bullet hit");
            SendMessage("interact", collision.collider.gameObject);

            if (!Repeat)
            {
                Destroy(btn);
                state = false;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {        
        IsActive = false;
        Destroy(btn);
    }


    public bool getCurrentState()
    {
        return state;
    }

    private void Update()
    {
        //按键互动
        if (PressToInteract && IsActive && (Input.GetKeyUp(KeyCode.F) || ETCInput.GetButtonUp("interactBtn")))
        {
            //调用对象脚本中的 interact() 方法
            //完成相应道具的操作

            Debug.Log("Pressed");

            SendMessage("interact", Player);

            if (!Repeat)
            {
                Destroy(btn);
                state = false;
            }
        }
    }

    //public void onjotypre
    //{
    //    send
    //}
}
