using System.IO;
using System.Xml;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTraper : MonoBehaviour
{
    private string scene_name;

    private int room_flag;

    private int door_flag;

    private void SaveRoom()
    {
        // 得到关卡的名称创建地址
        string filepath = Application.dataPath + @"/StreamingAssets/" + scene_name + ".xml";
        // 打开这个关卡
        XmlDocument xmlDoc = new XmlDocument();
        XmlElement root = xmlDoc.CreateElement("GObjects");
        foreach (GameObject obj in UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects())
        {
            if ((obj.transform.parent == null) && (obj.name != "Main Camera") && (obj.name != "Player") &&
                (obj.name != "Loader") && (obj.name != "Classroom(Clone)")&&(obj.name != "Bathroom(Clone)"))
            {
                XmlElement gameObject = xmlDoc.CreateElement("gameObjects");
                if (obj.name.Substring(obj.name.Length - 7).Equals("(Clone)"))
                {
                    gameObject.SetAttribute("name", obj.name.Substring(0, obj.name.Length - 7));
                    gameObject.SetAttribute("asset", obj.name.Substring(0, obj.name.Length - 7) + ".prefab");
                }
                else
                {
                    gameObject.SetAttribute("name", obj.name);
                    gameObject.SetAttribute("asset", obj.name + ".prefab");
                }

                XmlElement transform = xmlDoc.CreateElement("transform");
                XmlElement position = xmlDoc.CreateElement("position");
                XmlElement position_x = xmlDoc.CreateElement("x");
                position_x.InnerText = obj.transform.position.x + "";
                XmlElement position_y = xmlDoc.CreateElement("y");
                position_y.InnerText = obj.transform.position.y + "";
                XmlElement position_z = xmlDoc.CreateElement("z");
                position_z.InnerText = obj.transform.position.z + "";
                position.AppendChild(position_x);
                position.AppendChild(position_y);
                position.AppendChild(position_z);

                XmlElement rotation = xmlDoc.CreateElement("rotation");
                XmlElement rotation_x = xmlDoc.CreateElement("x");
                rotation_x.InnerText = obj.transform.rotation.eulerAngles.x + "";
                XmlElement rotation_y = xmlDoc.CreateElement("y");
                rotation_y.InnerText = obj.transform.rotation.eulerAngles.y + "";
                XmlElement rotation_z = xmlDoc.CreateElement("z");
                rotation_z.InnerText = obj.transform.rotation.eulerAngles.z + "";
                rotation.AppendChild(rotation_x);
                rotation.AppendChild(rotation_y);
                rotation.AppendChild(rotation_z);

                XmlElement scale = xmlDoc.CreateElement("scale");
                XmlElement scale_x = xmlDoc.CreateElement("x");
                scale_x.InnerText = obj.transform.localScale.x + "";
                XmlElement scale_y = xmlDoc.CreateElement("y");
                scale_y.InnerText = obj.transform.localScale.y + "";
                XmlElement scale_z = xmlDoc.CreateElement("z");
                scale_z.InnerText = obj.transform.localScale.z + "";

                scale.AppendChild(scale_x);
                scale.AppendChild(scale_y);
                scale.AppendChild(scale_z);

                transform.AppendChild(position);
                transform.AppendChild(rotation);
                transform.AppendChild(scale);

                gameObject.AppendChild(transform);
                root.AppendChild(gameObject);
                xmlDoc.AppendChild(root);
                xmlDoc.Save(filepath);
            }
        }

    }

    private void EnterDoor()
    {
        scene_name = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        room_flag = int.Parse(scene_name.Substring(scene_name.Length - 1));
        door_flag = int.Parse(this.name.Substring(this.name.Length - 1));

        //DontDestroyOnLoad(GameObject.Find("GameHolder"));
        DontDestroyOnLoad(GameObject.Find("Player(Clone)"));

        int next_room_flag = GameHolder.linkroom[room_flag, door_flag];

        if (GameHolder.room_type[next_room_flag] == 1)// 是教室
        {
            GameObject.Find("Player(Clone)").transform.position = GameHolder.classroom_pos[(door_flag + 2) % 4];
        }
        else if (GameHolder.room_type[next_room_flag] == 2)// 是浴室
        {
            GameObject.Find("Player(Clone)").transform.position = GameHolder.bathroom_pos[(door_flag + 2) % 4];
        }

        SaveRoom();

        UnityEngine.SceneManagement.SceneManager.LoadScene("Room" + next_room_flag);
    }

    void Update()
    {
        if (this.GetComponent<Interaction>().getCurrentState())
        {
            Debug.Log("Entering!");
            EnterDoor();
        }
        else
        {

        }
    }

}
