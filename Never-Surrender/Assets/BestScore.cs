using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public Text text;
    public string levelName;
    private float time;
    void Start()
    {
        time = PlayerPrefs.GetFloat(levelName + "Best");
        text.text = ((int)time / 60).ToString() + ":" + (time % 60).ToString("f2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
