using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPoint : MonoBehaviour {


    private float m_bulletTimer = 0;//射击速度计时器
    public Transform m_bullet;//子弹对象
    public Quaternion m_randomRotation;//子弹散射控制
    public float shootingSpeed=0.2f;//射击速度，时间间隔

    public AudioClip m_shootClip; //射击声音
    protected AudioSource m_audio; //声音源

    private bool Shot = false;

    public void weaponTriggered()
    {
        Shot = true;
    }

    // Use this for initialization
    void Start () {
        m_audio = this.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        m_bulletTimer -= Time.deltaTime;
        if (m_bulletTimer <= 0 )
        {

            if (Shot)
            {
                //随机角度散射
                m_randomRotation = transform.rotation;
                m_randomRotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + Random.Range(-3, 3)));

                Instantiate(m_bullet, transform.position, m_randomRotation);
                //射击声音
                m_audio.PlayOneShot(m_shootClip);

                //弹药减少
                //Ammo--;
                //Debug.Log("Ammo: " + Ammo);

                m_bulletTimer = shootingSpeed;
                Shot = false;
            }
        }

        //无弹药时武器消失

    }
}
