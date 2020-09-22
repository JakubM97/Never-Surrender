using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void StartNewGame(string Name)
    {
        SceneManager.LoadScene(Name);
    }
    public void BackToMenu()
    {
        GameObject.Find("SavedGame").GetComponent<SavedData>().speedrun = false;
        SceneManager.LoadScene("Menu");
    }
}
