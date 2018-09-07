using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 检测可互动物品
/// 挂载在角色的BtnDetector上
/// 一个跟随角色移动的Collider
/// 遇到可互动的物体会让物体提示
/// 与interaction.cs配合
/// </summary>

public class ItemDetector : MonoBehaviour
{

    public PlayerMovementControl playerMovement;

    private void Start()
    {
        playerMovement = transform.parent.GetComponent<PlayerMovementControl>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerMovement.PlayerTowards == PlayerMovementControl.PLAYER_TOWARDS.DOWN)
        {
            transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, 0));
        }
        if (playerMovement.PlayerTowards == PlayerMovementControl.PLAYER_TOWARDS.UP)
        {
            transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, 180));
        }
        if (playerMovement.PlayerTowards == PlayerMovementControl.PLAYER_TOWARDS.RIGHT)
        {
            transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, 90));
        }
        if (playerMovement.PlayerTowards == PlayerMovementControl.PLAYER_TOWARDS.LEFT)
        {
            transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, 270));
        }



        //旧版跟随移动方向
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, 180));
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, 0));
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, 270));
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, 90));
        //}
    }
}
