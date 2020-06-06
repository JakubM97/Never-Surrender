using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaPlay : MonoBehaviour
{
    public bool isActive;
    public int maxLimite = 300;
    private int time = 0;
    float plateformInitialPosition;
    private AudioSource audio;
    public AudioClip electricity;
    void Start()
    {
        plateformInitialPosition = transform.position.y;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlateform();
    }

    void movePlateform()
    {
        Vector3 tempY = this.transform.position;
        int tempTime = time;
        
        tempTime++;
        time = tempTime;
        limitReached(tempTime);

        if (time < -50)
        {
            tempY.y = 2000;
        }
        else
        {
            tempY.y = plateformInitialPosition;
        }
        this.transform.position = tempY;
    }

    void limitReached(int tempTime)
    {
        if (tempTime >=  maxLimite)
        {
            time *= -1;
        }
    }

}
