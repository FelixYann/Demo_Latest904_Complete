using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float m_speed = 10f;//飞行速度
    public float m_liveTime = 1;//持续时间
    public GameObject exp;

    public int BulletDamage;

    protected Transform m_transform;

    public void setBulletDamage(int d)
    {
        BulletDamage = d;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Detector" && collision.collider.tag != "skip" && collision.collider.tag != "Player")
        {
            Destroy(gameObject);
        }
        if (collision.collider.tag == "monster")
        {
            collision.gameObject.GetComponent<EnemyStatusControl>().damageItem(BulletDamage);

        }
    }


    public void OnDestroy()
    {
        Instantiate(exp,m_transform.position,m_transform.rotation);
    }


    // Use this for initialization
    void Start () {
        m_transform = this.transform;
        Destroy(this.gameObject, m_liveTime);
    }
	
	// Update is called once per frame
	void Update () {
        m_transform.Translate(new Vector3(-m_speed * Time.deltaTime, 0, 0));
    }
}
