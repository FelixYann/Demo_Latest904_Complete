using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSpliting : MonoBehaviour {
    public GameObject remains;
    GameObject temp;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Hit！");
            Vector3 playerPivot = col.gameObject.transform.position;
            Vector3 force = transform.position - playerPivot;

            temp = Instantiate(remains, transform.position, transform.rotation) as GameObject;
            var tempChildren = temp.GetComponentsInChildren<Rigidbody2D>();
            foreach (var item in tempChildren)
            {
                
                Vector3 randomDirection = force + new Vector3(force.x * Random.Range(-1, 3), force.y* Random.Range(-1, 3));
                item.AddForce(randomDirection * 100);
            }
            Debug.Log(force);
            Destroy(gameObject);
        }
    }
}
