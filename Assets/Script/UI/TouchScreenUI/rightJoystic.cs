using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightJoystic : MonoBehaviour
{

    private ETCJoystick myJoy;

    PlayerMovementControl playerScript;

    void Start()
    {
        var temp = GameObject.Find("Player(Clone)");
        playerScript = temp.GetComponent<PlayerMovementControl>();

        myJoy = ETCInput.GetControlJoystick("rightJoystick");

    }


    void Update()
    {

        //获取摇杆水平轴的值

        float h = myJoy.axisX.axisValue;

        //获取摇杆垂直轴的值

        float v = myJoy.axisY.axisValue;

        if (h != 0 || v != 0)
        {
            //获取摇杆的方向
            Vector3 dir = new Vector3(h, v, 0);
            dir = Camera.main.transform.TransformDirection(dir);
            dir.z = 0;
            Vector3 rotate = new Vector3(dir.x, dir.y);
            playerScript.Rotate(rotate);
        }


    }
}
