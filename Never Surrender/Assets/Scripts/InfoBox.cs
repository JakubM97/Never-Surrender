﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InfoBox : MonoBehaviour
{
    public float speed = 0.125f;
    public bool isVerticalMovement;
    bool hide = false;
    float distance = 0;
    public ParticleSystem smoke;
    public ParticleSystem smoke2;
    //private List<GameObject> smokeList;
    //GameObject s1, s2;
    void Start()
    {

        StartCoroutine(LimitReached());
        StartCoroutine(LimitSmoke());
        
    }

    void FixedUpdate()
    {
        
        if (hide && distance <=30)
        {
            Vector3 tempPlatformPosition = this.transform.position;
            if (isVerticalMovement)
            {
                tempPlatformPosition.y += speed;
            }
            else
            {
                tempPlatformPosition.x += speed;
            }
            this.transform.position = tempPlatformPosition;
            distance += speed;
        }
    }

    IEnumerator LimitReached()
    {
        yield return new WaitForSecondsRealtime(5);
        hide = true;
    }
    IEnumerator LimitSmoke()
    {
        yield return new WaitForSecondsRealtime(7);
        smoke.Stop(false);
        smoke2.Stop(false);
    }
}
