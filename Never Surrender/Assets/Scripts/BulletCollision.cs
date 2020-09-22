using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Bullet"))
        {
            
            Destroy(col.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {

        if (col.gameObject.tag.Equals("Bullet"))
        {
            Destroy(col.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag.Equals("Bullet"))
        {

            Destroy(col.gameObject);
        }
    }
}
