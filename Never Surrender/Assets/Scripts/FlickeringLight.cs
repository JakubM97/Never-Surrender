using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Experimental.Rendering.Universal;

public class FlickeringLight : MonoBehaviour
{
    private float Timer=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Blink();
    }

    void Blink()
    {
        if (Timer > 0)
        {
            this.GetComponent<Light2D>().enabled = !this.GetComponent<Light2D>().enabled;
            Timer = -100f;
        }
        else Timer++;
    }
}
