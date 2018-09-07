using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 负责控制角色手上的武器
/// 武器攻击、旋转
/// </summary>

public class PlayerEquipmentControl : MonoBehaviour {

    public GameObject Equipment; //武器对象
    public bool IsEquip = false; //判断玩家是否持有武器

    private Quaternion weaponRotation; //武器旋转方向
    private Transform EquipmentTransform;

    private ETCJoystick rjs;//摇杆

    // Use this for initialization
    void Start()
    {
        rjs = ETCInput.GetControlJoystick("rightJoystick");
    }

    //返回当前是否装备有武器
    public bool isEquip()
    {
        return IsEquip;
    }

    //角色装备道具
    public void equipPlayer(GameObject equipment)
    {
        //Debug.Log("Player Equiping");
        IsEquip = true;
        Equipment = equipment;
        EquipmentTransform = Equipment.transform;
        EquipmentTransform.SetParent(this.transform);

    }

    //角色卸下装备
    public void unequipPlayer()
    {
        IsEquip = false;

        //将装备还原为初始状态
        Equipment.GetComponent<BoxCollider2D>().enabled = true;
        EquipmentTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        EquipmentTransform.localScale = new Vector3(1.5f, 1.5f);
        Equipment.transform.parent = null;
        Equipment = null;
    }


    void Update()
    {
        if (IsEquip)
        {
            Equipment.GetComponent<BoxCollider2D>().enabled = false;
            EquipmentTransform.position = this.transform.position;


            //背对着摄像机时抢在身前
            if(this.GetComponent<PlayerMovementControl>().PlayerTowards == PlayerMovementControl.PLAYER_TOWARDS.UP)
            {
                EquipmentTransform.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            else
            {
                EquipmentTransform.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }


            //键盘射击方案
            if (GetComponent<PlayerMovementControl>().controlMode == PlayerMovementControl.CONTROL_MODE.Keyboard)
            {

                //得到指向鼠标的向量
                Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                //计算角度（tan = y/x）
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 180;
                weaponRotation = Quaternion.AngleAxis(angle, Vector3.forward);
                //根据角度进行旋转
                EquipmentTransform.rotation = Quaternion.Slerp(EquipmentTransform.rotation, weaponRotation, Equipment.GetComponent<WeaponControl>().RotationSpeed * Time.deltaTime);

                //武器随鼠标旋转时朝向调整
                if (EquipmentTransform.eulerAngles.z <= 270 && EquipmentTransform.eulerAngles.z >= 90)
                {
                    EquipmentTransform.localScale = new Vector3(1.5f, -1.5f);
                }
                else
                {
                    EquipmentTransform.localScale = new Vector3(1.5f, 1.5f);
                }

                if (Input.GetMouseButton(0))
                {
                    Debug.Log("Weapon Trigger");
                    Equipment.GetComponent<WeaponControl>().Trigger();
                }
                else
                {
                    Equipment.GetComponent<WeaponControl>().UnTrigger();
                }
            }


            //摇杆射击方案
            if(GetComponent<PlayerMovementControl>().controlMode == PlayerMovementControl.CONTROL_MODE.TouchScreen)
            {
                //得到摇杆的向量
                float rightValueX = rjs.axisX.axisValue;
                float rightValueY = rjs.axisY.axisValue;

                Vector2 direction = new Vector2(rightValueX, rightValueY);
                //计算角度（tan = y/x）
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 180;
                weaponRotation = Quaternion.AngleAxis(angle, Vector3.forward);
                //根据角度进行旋转
                EquipmentTransform.rotation = Quaternion.Slerp(EquipmentTransform.rotation, weaponRotation, Equipment.GetComponent<WeaponControl>().RotationSpeed * Time.deltaTime);

                //武器随鼠标旋转时朝向调整
                if (EquipmentTransform.eulerAngles.z <= 270 && EquipmentTransform.eulerAngles.z >= 90)
                {
                    EquipmentTransform.localScale = new Vector3(1.5f, -1.5f);
                }
                else
                {
                    EquipmentTransform.localScale = new Vector3(1.5f, 1.5f);
                }

                //射击
                if ((Mathf.Abs(rightValueX) > 0.8 || Mathf.Abs(rightValueY) > 0.8))
                {
                    Equipment.GetComponent<WeaponControl>().Trigger();
                }
                else
                {
                    Equipment.GetComponent<WeaponControl>().UnTrigger();
                }
            }
        }
    }


}
