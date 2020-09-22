using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Config;

public class SawMoving : MonoBehaviour
{
    private float speed = Config.sawSpeed;
    public int maxLimite = Config.sawMaxLimite;
    public bool isVerticalMovement;
    float platformInitialPosition;
    public bool isPlatformMoving;

    void Start()
    {
        if(isVerticalMovement)
        {
            platformInitialPosition = transform.position.y;
        }
        else
        {
            platformInitialPosition = transform.position.x;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isPlatformMoving)
        {
            movePlatform();
        }
    }

    void movePlatform()
    {
        Vector3 tempPlatformPosition = this.transform.position;
        if(isVerticalMovement)
        {
            limitReached(tempPlatformPosition.y);
            tempPlatformPosition.y += speed;
        }
        else
        {
            limitReached(tempPlatformPosition.x);
            tempPlatformPosition.x += speed;
        }

        this.transform.position = tempPlatformPosition;
    }

    void limitReached(float platformPosition)
    {
        if((platformPosition >= (platformInitialPosition+maxLimite)) || (platformPosition <= (platformInitialPosition - maxLimite)))
        {
            speed *= -1;
        }
    }
}
