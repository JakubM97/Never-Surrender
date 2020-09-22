using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrokenStopwatch : MonoBehaviour
{
    private int brokenh = 0, brokenm = 0, brokens = 0, h, m, s;
    void FixedUpdate()
    {
        if (brokenh > Random.Range(20, 25))
        {
            h = Random.Range(0, 9);
            brokenh = 0;
        }
        if (brokenm > Random.Range(15, 20))
        {
            m = Random.Range(0, 60);
            brokenm = 0;
        }
        if (brokens > Random.Range(10, 15))
        {
            s = Random.Range(0, 60);
            brokens = 0;
        }

        if(m < 10 && s < 10)
        {
            this.GetComponent<Text>().text = h + ":0" + m + ":0" + s;
        }
        else if(m>=10 && s<10)
        {
            this.GetComponent<Text>().text = h + ":" + m + ":0" + s;
        }
        else if(m < 10 && s >= 10)
        {
            this.GetComponent<Text>().text = h + ":0" + m + ":" + s;
        }
        else this.GetComponent<Text>().text = h + ":" + m + ":" + s;

        brokenh++;
        brokenm++;
        brokens++;
    }
}
