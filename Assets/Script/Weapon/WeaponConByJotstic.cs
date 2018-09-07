using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 武器道具的统一脚本
/// 统一控制武器的属性状态
/// 包括拾取武器、武器的伤害值、弹药消耗量、
/// 摇杆版本
/// </summary>

public class WeaponConByJotstic : MonoBehaviour
{

    public float RotationSpeed = 10f; //武器跟随鼠标旋转速度，可表示武器重量的影响
    public float attackSpeed = 0.2f;//攻击速度，时间间隔
    public int DamagePerHit = 1; //武器的单发伤害值
    public bool NeedAmmo = true; //武器是否需要弹药
    public int AmmoNeeded = 1; //武器消耗的弹药量

    public AudioClip gunfireAudio;
    public AudioClip dryfireAudio;

    protected AudioSource m_audio; //声音源

    private bool IsEquip; //武器是否被装备上
    private float m_bulletTimer = 0;//射击速度计时器
    private GameObject player; //玩家

    private ETCJoystick rightJoystic;//摇杆


    public bool isEquip()
    {
        return IsEquip;
    }

    //拾取武器
    public void interact(GameObject other)
    {
        Debug.Log("In Touch Control Equip");
        IsEquip = true;
        this.transform.SetParent(other.transform);
        other.GetComponent<PlayerEquipmentControl>().equipPlayer(this.gameObject);
        player = other;
    }

    // Use this for initialization
    void Start()
    {
        IsEquip = false;
        m_audio = this.GetComponent<AudioSource>();
        rightJoystic = ETCInput.GetControlJoystick("rightJoystic");
    }

    // Update is called once per frame
    void Update()
    {

        if (IsEquip)
        {

            this.GetComponent<BoxCollider2D>().enabled = false;
            this.transform.position = player.transform.position;

            //武器随鼠标旋转时朝向调整
            if (transform.eulerAngles.z <= 270 && transform.eulerAngles.z >= 90)
            {
                transform.localScale = new Vector3(1.5f, -1.5f);
            }
            else
            {
                transform.localScale = new Vector3(1.5f, 1.5f);
            }

            //得到摇杆的向量
            float rightValueX = rightJoystic.axisX.axisValue;
            float rightValueY = rightJoystic.axisY.axisValue;

            Vector2 direction = new Vector2(rightValueX, rightValueY);
            //计算角度（tan = y/x）
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 180;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //根据角度进行旋转
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, RotationSpeed * Time.deltaTime);


            //武器攻击时间间隔计时
            m_bulletTimer -= Time.deltaTime;
            if (m_bulletTimer <= 0 && (Mathf.Abs(rightValueX)>0.4 || Mathf.Abs(rightValueY) > 0.4))
            {

                //如果弹药足够，攻击一次
                if (player.GetComponent<PlayerStatusControl>().consumeAmmo(AmmoNeeded))
                {
                    BroadcastMessage("weaponTriggered", DamagePerHit);
                    //射击声音
                    m_audio.PlayOneShot(gunfireAudio);
                }
                else
                {
                    m_audio.PlayOneShot(dryfireAudio);
                }

                //重置计时器
                m_bulletTimer = attackSpeed;
            }

        }
    }
}
