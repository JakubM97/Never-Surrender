using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 velocity;
    public void SetVelocityVectors (float x, float y, float magnitude)
    {
        velocity = new Vector3(x * Time.deltaTime, y * Time.deltaTime , 0f) * magnitude;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(velocity);
    }
}
