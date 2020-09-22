using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Config;

public class IsLocked : MonoBehaviour
{
    public int whichLevel = Config.whichLevel;
    public bool isUnlocked = Config.isUnlocked;
    public string[] levels = Config.levels;
    public Color color;

    private void Start()
    {
        color = this.GetComponent<Image>().color;
        if (whichLevel != 0)
        {
            if (PlayerPrefs.GetFloat(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave + levels[whichLevel - 1] + "Best") == 0)
            {
                color.a = 0.2f;
                this.GetComponent<Image>().color = color;
            }
            else
            {
                color.a = 1f;
                this.GetComponent<Image>().color = color;
            }
        }
    }

    public void CheckIfLocked()
    {
        if (whichLevel == 0)
        {
            SceneManager.LoadScene(levels[whichLevel]);
        }else if (PlayerPrefs.GetFloat(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave + levels[whichLevel - 1] + "Best") != 0)
        {
            SceneManager.LoadScene(levels[whichLevel]);
        }

    }
}
