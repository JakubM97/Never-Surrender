using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Config;
using TMPro;

public class BestScore : MonoBehaviour
{
    public Text text;
    public TextMeshProUGUI speedrunText;
    public string levelName;
    private float time;

    void Start()
    {
        if (levelName != "SpeedRun")
        {
            time = PlayerPrefs.GetFloat(levelName + "Best");
            text.text = ((int)time / 60).ToString() + ":" + (time % 60).ToString("f2");
        }
        else
        {
            speedrunText.text = ((int)PlayerPrefs.GetFloat("SpeedRun") / 60).ToString() + ":" + (PlayerPrefs.GetFloat("SpeedRun") % 60).ToString("f2");
            
        }
    }
}
