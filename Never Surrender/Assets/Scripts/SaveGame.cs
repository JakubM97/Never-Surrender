using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave.ToString() + "HP") != 0)
        {
            GameObject.Find("SavedGame").GetComponent<SavedData>().SaveActualGame();
        }
    }
}
