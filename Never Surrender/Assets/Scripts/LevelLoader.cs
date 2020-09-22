using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Config;

public class LevelLoader : MonoBehaviour
{
    public int whichSave = Config.whichSave;
    public Text timerText;
    public int[,] HighScore = new int[12, 3];
    private bool playerInZone;
    public string levelToLoad;
    public float startTime = Config.startTime;
    private float t;
    public string levelName;
    public GameObject player;
    public Animator anim;
    void Start()
    {
        playerInZone = false;

        startTime = Time.time;

        timerText.text = "";
        this.gameObject.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInZone)
        {
            if (levelName == "Level2_4" && GameObject.Find("SavedGame").GetComponent<SavedData>().secretUnlocked)
            {
                
                SceneManager.LoadScene("Secret");
            }
            else
            {
                if(levelName == "Secret")
                {
                    GameObject.Find("SavedGame").GetComponent<SavedData>().secretCompleted = true;
                }
                SceneManager.LoadScene(levelToLoad);
            }
            
        }
        if (GameObject.Find("SavedGame").GetComponent<SavedData>().gameOver == false)
        {
            if (!GameObject.Find("SavedGame").GetComponent<SavedData>().speedrun)
            {
                t = Time.time - startTime;
            }
            else
            {
                t = Time.time - startTime + GameObject.Find("SavedGame").GetComponent<SavedData>().time;
            }
        }
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerText.text = minutes + ":" + seconds;

        if (player != null && this != null)
        {
            if (Vector2.Distance(player.transform.position, this.transform.position) < 35)
            {
                this.gameObject.GetComponent<Animator>().enabled = true;
                anim.SetBool("OnRange", true);
            }
            else
            {
                anim.SetBool("OnRange", false);
            }
        }
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (!GameObject.Find("SavedGame").GetComponent<SavedData>().speedrun)
        {
            if (GameObject.Find("SavedGame").GetComponent<SavedData>().difficulty == "Normal")
            {
                if (PlayerPrefs.GetFloat(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave + levelName + "Best") > t || PlayerPrefs.GetFloat(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave + levelName + "Best") == 0)
                {
                    PlayerPrefs.SetFloat(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave + levelName + "Best", t);
                }
                GameObject.Find("SavedGame").GetComponent<SavedData>().SaveActualGame();
                if (levelName == "Level3_4")
                {
                    PlayerPrefs.SetInt("NormalComplete", 1);
                }
            }
            else if (GameObject.Find("SavedGame").GetComponent<SavedData>().difficulty == "Hard")
            {
                if (PlayerPrefs.GetFloat(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave + levelName + "Best") > t || PlayerPrefs.GetFloat(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave + levelName + "Best") == 0)
                {
                    PlayerPrefs.SetFloat(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave + levelName + "Best", t);
                }
                GameObject.Find("SavedGame").GetComponent<SavedData>().SaveActualGame();
                if (levelName == "Level3_4")
                {
                    PlayerPrefs.SetInt("HardComplete", 1);
                    if(GameObject.Find("SavedGame").GetComponent<SavedData>().playerHealth == 20)
                    {
                        PlayerPrefs.SetInt("HardOrNightmareComplete", 1);
                    }
                }
            }
            else if (GameObject.Find("SavedGame").GetComponent<SavedData>().difficulty == "Nightmare")
            {
                if (PlayerPrefs.GetFloat(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave + levelName + "Best") > t || PlayerPrefs.GetFloat(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave + levelName + "Best") == 0)
                {
                    PlayerPrefs.SetFloat(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave + levelName + "Best", t);
                }
                GameObject.Find("SavedGame").GetComponent<SavedData>().SaveActualGame();
                if (levelName == "Level3_4")
                {
                    PlayerPrefs.SetInt("NightmareComplete", 1);
                }
            }

            if (levelName == "Level3_4")
            {
                PlayerPrefs.DeleteKey(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave.ToString().ToString());
                PlayerPrefs.DeleteKey(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave.ToString().ToString() + "HP");
                PlayerPrefs.SetInt(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave.ToString() + "Completed", 1);
                if(PlayerPrefs.GetInt("1Completed")==1 && PlayerPrefs.GetInt("4Completed") == 1 && PlayerPrefs.GetInt("7Completed") == 1)
                {
                    PlayerPrefs.SetInt("CompleteOneSave", 1);
                }
                if (PlayerPrefs.GetInt("2Completed") == 1 && PlayerPrefs.GetInt("5Completed") == 1 && PlayerPrefs.GetInt("8Completed") == 1)
                {
                    PlayerPrefs.SetInt("CompleteOneSave", 1);
                }
                if (PlayerPrefs.GetInt("3Completed") == 1 && PlayerPrefs.GetInt("6Completed") == 1 && PlayerPrefs.GetInt("9Completed") == 1)
                {
                    PlayerPrefs.SetInt("CompleteOneSave", 1);
                }
                GameObject.Find("YouWin").SetActive(true);
            }
            
            if (collision.name == "Player")
            {
                GameObject.Find("SavedGame").GetComponent<SavedData>().time = t;
                playerInZone = true;
            }
        }
        else
        {
            if (levelName == "Level3_4")
            {
                PlayerPrefs.SetFloat("SpeedRun", t);
                GameObject.Find("SavedGame").GetComponent<SavedData>().time = 0f;
                GameObject.Find("SavedGame").GetComponent<SavedData>().speedrun = false;
            }
        }
    }
        void OnTriggerExit2D(Collider2D collision)
        {

            if (collision.name == "Player")
            {
                playerInZone = false;
            }
        }
    }

