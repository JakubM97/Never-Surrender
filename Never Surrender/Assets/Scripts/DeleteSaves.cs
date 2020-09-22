using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeleteSaves : MonoBehaviour
{
    public void DeleteSave(int saveNumber)
    {
        PlayerPrefs.DeleteKey(saveNumber.ToString());
        PlayerPrefs.DeleteKey(saveNumber.ToString() + "HP");
    }

    public void DeleteAllSaves()
    {
        PlayerPrefs.DeleteAll();
        GameObject.Find("SavedGame").GetComponent<SavedData>().secret = false;
        GameObject.Find("SavedGame").GetComponent<SavedData>().secretUnlocked = false;
        GameObject.Find("SavedGame").GetComponent<SavedData>().secretCompleted = false;
        GameObject.Find("SavedGame").GetComponent<SavedData>().coinCollected = false;
    }
}
