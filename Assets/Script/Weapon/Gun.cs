using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject m_bullet;//子弹对象
    public float dispareRange; //子弹散射范围
    public GameObject gunFireMotion;

    private Quaternion m_randomRotation;//子弹散射控制

    //控制枪的攻击方式
    public void weaponTriggered(int damage)
    {
        //随机角度散射
        m_randomRotation = transform.rotation;
        m_randomRotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + Random.Range(-dispareRange, dispareRange)));

        m_bullet.GetComponent<Bullet>().setBulletDamage(damage);

        Vector3 BulletPos = m_randomRotation * new Vector3(-0.9f, 0, 0) + transform.position;
        Instantiate(m_bullet, BulletPos, m_randomRotation);

        Vector3 FirePos = transform.rotation * new Vector3(-0.5f, 0, 0) + transform.position;
        Instantiate(gunFireMotion, FirePos, transform.rotation);
    }



}
