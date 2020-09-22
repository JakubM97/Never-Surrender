using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{
    public void LoadActualGame()
    {
        if (PlayerPrefs.GetInt(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave.ToString() + "HP") != 0)
        {
            GameObject.Find("SavedGame").GetComponent<SavedData>().playerHealth = PlayerPrefs.GetInt(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave.ToString() + "HP");
            SceneManager.LoadScene(PlayerPrefs.GetString(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave.ToString()));
        }else
        {
            SceneManager.LoadScene("Level1_1");
        }
    }

    
}
