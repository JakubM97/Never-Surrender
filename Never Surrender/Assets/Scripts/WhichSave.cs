using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Config;

public class WhichSave : MonoBehaviour
{
   
    public void WhichSaveItIs(int which)
    {
        GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave = which;
    }
    public void Speedrun(bool isSpeedrun)
    {
        GameObject.Find("SavedGame").GetComponent<SavedData>().speedrun = isSpeedrun;
        SceneManager.LoadScene("Level1_1");
    }

    public void SetDifficulty(string diff)
    {
        GameObject.Find("SavedGame").GetComponent<SavedData>().difficulty = diff;
        if(diff == "Normal")
        {
            GameObject.Find("SavedGame").GetComponent<SavedData>().playerHealth = -10;
        }else if(diff == "Hard")
        {
            GameObject.Find("SavedGame").GetComponent<SavedData>().playerHealth = 20;
        }else if(diff == "Nightmare")
        {
            GameObject.Find("SavedGame").GetComponent<SavedData>().playerHealth = 1;
        }
        SceneManager.LoadScene("Level1_1");
    }
}
