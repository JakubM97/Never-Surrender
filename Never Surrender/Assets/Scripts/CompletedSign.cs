using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompletedSign : MonoBehaviour
{
    private float changeColor = 0.006f;
    private Color color;

    [SerializeField]
    private int whichSave;
    [SerializeField]
    private GameObject glow;

    void Start()
    {
        color = glow.gameObject.GetComponent<RawImage>().color;
        if (PlayerPrefs.GetInt(whichSave + "Completed") == 1)
        {
            glow.SetActive(true);
        }else
        {
            glow.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        if(PlayerPrefs.GetInt(whichSave + "Completed") != 1)
        {
            color.a -= changeColor;
            glow.gameObject.GetComponent<RawImage>().color = color;
            
            if (color.a < 0.6f || color.a > 1.01f)
            {
                changeColor *= -1;
            }
            Debug.Log(glow.transform.localScale.x);
        }
    }
}
