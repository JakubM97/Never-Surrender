using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMoving : MonoBehaviour
{
    public float speed = 0.125f;
    public int maxLimite = 5;
    public bool isVerticalMovement;
    float plateformInitialPosition;
    public bool isPlateformMoving;

    void Start()
    {
        if(isVerticalMovement)
        {
            plateformInitialPosition = transform.position.y;
        }
        else
        {
            plateformInitialPosition = transform.position.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlateformMoving)
        {
            movePlateform();
        }
    }

    void movePlateform()
    {
        Vector3 tempPlateformPosition = this.transform.position;
        if(isVerticalMovement)
        {
            limitReached(tempPlateformPosition.y);
            tempPlateformPosition.y += speed;
        }
        else
        {
            limitReached(tempPlateformPosition.x);
            tempPlateformPosition.x += speed;
        }

        this.transform.position = tempPlateformPosition;
    }

    void limitReached(float plateformPosition)
    {
        if((plateformPosition >= (plateformInitialPosition+maxLimite)) || (plateformPosition <= (plateformInitialPosition - maxLimite)))
        {
            speed *= -1;
        }
    }
}
