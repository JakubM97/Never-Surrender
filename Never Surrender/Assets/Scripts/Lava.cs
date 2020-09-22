using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public GameObject[] particles;
    private int i = 0;
    private void FixedUpdate()
    {
        if(i > Random.Range(80,130))
        {
            particles[Random.Range(0, 4)].gameObject.GetComponent<ParticleSystem>().Play();
            i = 0;
        }
        i++;
    }

}
