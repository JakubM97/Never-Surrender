using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject playerTarget;
    public float fireRate = 100;
    public Rigidbody2D bullet;
    public GameObject level;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(0f, 0f, 90f);
        
    }

    // Update is called once per frame
    void Update()
    {
        time += 0.01f;
        float degrees = Mathf.Atan2(transform.position.y - playerTarget.transform.position.y, transform.position.x - playerTarget.transform.position.x) * Mathf.Rad2Deg + 90f;
        transform.eulerAngles = new Vector3(0f, 0f, degrees);
        
        if (IsNearTargetAngle(transform.eulerAngles.z, degrees, 5f))
        {
            if (time >= fireRate)
            {
                Rigidbody2D bulletClone = Instantiate(bullet, transform.position, Quaternion.identity);
                bulletClone.transform.parent = level.transform;
                Bullet bulletScript = bulletClone.GetComponent<Bullet>();

                bulletScript.SetVelocityVectors(
                    Mathf.Sin(degrees * Mathf.Deg2Rad) * (-1f),
                    Mathf.Cos(degrees * Mathf.Deg2Rad),
                    40f);


                time = 0f;
            }
        }
    }

    private bool IsNearTargetAngle(float current, float target, float offset)
    {
        if (Mathf.Abs(target - current) <= offset)
            return true;
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerTarget = collision.gameObject;
        
    }
}
