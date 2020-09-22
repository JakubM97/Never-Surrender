using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hp, gameover;
    public List<GameObject> health;

    private void Start()
    {
        SetHP();
        gameover.SetActive(false);
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f;
        }
        if (health.Count > GameObject.Find("SavedGame").GetComponent<SavedData>().playerHealth && health != null)
        {
            Destroy(health[GameObject.Find("SavedGame").GetComponent<SavedData>().playerHealth]);
            health.RemoveAt(health.Count - 1);
        }
        if(GameObject.Find("SavedGame").GetComponent<SavedData>().playerHealth <= 0)
        {
            gameover.SetActive(true);
            PlayerPrefs.DeleteKey(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave.ToString());
            PlayerPrefs.DeleteKey(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave.ToString() + "HP");
            GameObject.Find("SavedGame").GetComponent<SavedData>().gameOver = true;
        }
    }
    public void Pause()
    {
        if(Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
        
    }
    public void SetHP()
    {
      
        for (int i = 1; i < GameObject.Find("SavedGame").GetComponent<SavedData>().playerHealth + 1; i++)
        {
            health.Add(Instantiate(hp, new Vector2(-69, 39 - 3 * i), Quaternion.identity));
        }
        
    }
    public void Surrender()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
