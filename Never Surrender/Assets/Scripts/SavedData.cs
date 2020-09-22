using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Config;

public class SavedData : MonoBehaviour
{
    public int whichSave = Config.whichSave;
    public bool speedrun = Config.speedrun;
    public float time = Config.time;
    public string difficulty = Config.difficulty;
    public int playerHealth = Config.playerHealth;
    public bool gameOver = Config.gameOver;
    public bool coinCollected = false;
    public bool secretUnlocked = false;
    public bool secretCompleted = false;
    public bool secret = false;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void SaveActualGame()
    {
        PlayerPrefs.SetString(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave.ToString(), GameObject.Find("Door").GetComponent<LevelLoader>().levelName);
        PlayerPrefs.SetInt(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave.ToString() + "HP", GameObject.Find("SavedGame").GetComponent<SavedData>().playerHealth);
    }

}
