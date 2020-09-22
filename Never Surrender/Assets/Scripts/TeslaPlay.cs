using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaPlay : MonoBehaviour
{
    private int maxLimite = 200;
    private int time = 0;
    float platformInitialPosition;
    void Start()
    {
        platformInitialPosition = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movePlatform();
    }

    void movePlatform()
    {
        Vector3 tempY = this.transform.position;
        time++;
        limitReached(time);

        if (time < -50)
        {
            tempY.y = 2000;
        }
        else
        {
            tempY.y = platformInitialPosition;
        }
        this.transform.position = tempY;
    }

    void limitReached(int tempTime)
    {
        if (tempTime >=  maxLimite)
        {
            time = -time;
        }
    }

}
