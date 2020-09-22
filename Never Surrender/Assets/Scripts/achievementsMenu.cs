using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Achievements;
using static SavedData;

public class achievementsMenu : MonoBehaviour
{
    private string name;
    public Image[] image;
    public TextMeshProUGUI text;
    private string sceneName;
    public int whichAchi;
    public GameObject achiMask;
    public bool achievementCollected;
    private void Start()
    {
        
    }
    public void ShowInfo(int achiNum)
    {
        if (PlayerPrefs.GetString("achi" + image[achiNum].GetComponent<Image>().name) != "")
        {
            name = PlayerPrefs.GetString("achi" + image[achiNum].GetComponent<Image>().name);
            string[] names = name.Split(',');

            text.text = "Achievement name: \n" + names[0] + "\n\nDescription:\n" + names[1] + "\n\nDate:\n" + names[2];
        }
    }
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        GetAchievement();
        

    }

    public void GetAchievement()
    {
        if(PlayerPrefs.GetString("achi" + image[0].GetComponent<Image>().name) == "" && sceneName == "Level1_1")
        {
            Debug.Log("achi" + image[whichAchi].GetComponent<Image>().name);
            whichAchi = 0;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "Hello cruel world,Play the game for the first time," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        if (PlayerPrefs.GetString("achi" + image[1].GetComponent<Image>().name) == "" && PlayerScript.deathCount > 0)
        {
            whichAchi = 1;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "First blood,The first death in the game," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        if (PlayerPrefs.GetString("achi" + image[2].GetComponent<Image>().name) == "" && sceneName == "Level2_1")
        {
            whichAchi = 2;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "End of the beginning,Complete phase one," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        if (PlayerPrefs.GetString("achi" + image[3].GetComponent<Image>().name) == "" && sceneName == "Level3_1")
        {
            whichAchi = 3;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "Beginning of the end,Complete phase two," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        if (PlayerPrefs.GetString("achi" + image[4].GetComponent<Image>().name) == "" && PlayerPrefs.GetInt("NormalComplete") == 1)
        {
            whichAchi = 4;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "This was too easy,Complete the game on the normal difficulty," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        if (PlayerPrefs.GetString("achi" + image[5].GetComponent<Image>().name) == "" && PlayerPrefs.GetInt("HardComplete") == 1)
        {
            whichAchi = 5;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "It's just a scratch,Complete the game on the hard difficulty," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        if (PlayerPrefs.GetString("achi" + image[6].GetComponent<Image>().name) == "" && PlayerPrefs.GetInt("NightmareComplete") == 1)
        {
            whichAchi = 6;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "How did you…,Complete the game on the nightmare difficulty," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }
        
        if (PlayerPrefs.GetString("achi" + image[7].GetComponent<Image>().name) == "" && PlayerPrefs.GetInt("HardOrNightmareComplete") == 1)
        {
            whichAchi = 7;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "You should try nightmare difficulty,Complete the game on the hard difficulty without dying," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        if (PlayerPrefs.GetString("achi" + image[8].GetComponent<Image>().name) == "" && PlayerPrefs.GetInt("DeathBySaw") >= 100)
        {
            whichAchi = 8;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "That was SAWage,Die 100 times on sawes," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        if (PlayerPrefs.GetString("achi" + image[9].GetComponent<Image>().name) == "" && PlayerPrefs.GetInt("DeathByTesla") >= 100)
        {
            whichAchi = 9;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "FZZT,Die 100 times on tesla gates," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        if (PlayerPrefs.GetString("achi" + image[10].GetComponent<Image>().name) == "" && PlayerPrefs.GetInt("DeathBySpike") >= 100)
        {
            whichAchi = 10;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "This is spiky,Die 100 times on spikes," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        if (PlayerPrefs.GetString("achi" + image[11].GetComponent<Image>().name) == "" && PlayerPrefs.GetInt("DeathByBullet") >= 50)
        {
            whichAchi = 11;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "Bullet hell,Die 50 times from a bullet," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        if (PlayerPrefs.GetString("achi" + image[12].GetComponent<Image>().name) == "" && PlayerPrefs.GetInt("DeathBySlime") >= 50)
        {
            whichAchi = 12;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "Sticky!,Die 50 times on slime," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        if (PlayerPrefs.GetString("achi" + image[13].GetComponent<Image>().name) == "" && PlayerPrefs.GetInt("DeathByLava") >= 50)
        {
            whichAchi = 13;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "HOT HOT HOT!,Die 50 times in lava," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        if (PlayerPrefs.GetString("achi" + image[14].GetComponent<Image>().name) == "" && PlayerScript.deathCount >= 500)
        {
            whichAchi = 14;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "Don't worry you can do this,Die 500 times," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        if (PlayerPrefs.GetString("achi" + image[15].GetComponent<Image>().name) == "" && PlayerScript.deathCount >= 1000)
        {
            whichAchi = 15;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "I gues you liked it...,Die 1,000 times," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        if (PlayerPrefs.GetString("achi" + image[16].GetComponent<Image>().name) == "" && PlayerScript.deathCount >= 1500)
        {
            whichAchi = 16;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "Really?!,Die 1,500 times," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        if (PlayerPrefs.GetString("achi" + image[17].GetComponent<Image>().name) == "" && PlayerPrefs.GetInt("CompleteOneSave") == 1)
        {
            whichAchi = 17;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "There is nothing else to do here,Complete the game on all difficulty in one save," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        if (PlayerPrefs.GetString("achi" + image[18].GetComponent<Image>().name) == "" && PlayerPrefs.GetFloat("SpeedRun") > 0)
        {
            whichAchi = 18;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "I am speed,Complete the game as speedrun," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        if (PlayerPrefs.GetString("achi" + image[19].GetComponent<Image>().name) == "" && GameObject.Find("SavedGame").GetComponent<SavedData>().coinCollected)
        {
            whichAchi = 19;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "Completely useless coin,Collect One coin," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        if (PlayerPrefs.GetString("achi" + image[20].GetComponent<Image>().name) == "" && GameObject.Find("SavedGame").GetComponent<SavedData>().secret)
        {
            whichAchi = 20;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "Pointless level?,Get to hidden level," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        if (PlayerPrefs.GetString("achi" + image[21].GetComponent<Image>().name) == "" && GameObject.Find("SavedGame").GetComponent<SavedData>().secretCompleted)
        {
            whichAchi = 21;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "Shhh don't tell anyone about it,Complete hidden level," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        if (PlayerPrefs.GetString("achi" + image[22].GetComponent<Image>().name) == "" &&
            PlayerPrefs.GetString("achi" + image[19].GetComponent<Image>().name) != "" &&
            PlayerPrefs.GetString("achi" + image[18].GetComponent<Image>().name) != "" &&
            PlayerPrefs.GetString("achi" + image[17].GetComponent<Image>().name) != "" &&
            PlayerPrefs.GetString("achi" + image[16].GetComponent<Image>().name) != "" &&
            PlayerPrefs.GetString("achi" + image[15].GetComponent<Image>().name) != "" &&
            PlayerPrefs.GetString("achi" + image[14].GetComponent<Image>().name) != "" &&
            PlayerPrefs.GetString("achi" + image[13].GetComponent<Image>().name) != "" &&
            PlayerPrefs.GetString("achi" + image[12].GetComponent<Image>().name) != "" &&
            PlayerPrefs.GetString("achi" + image[11].GetComponent<Image>().name) != "" &&
            PlayerPrefs.GetString("achi" + image[10].GetComponent<Image>().name) != "" &&
            PlayerPrefs.GetString("achi" + image[9].GetComponent<Image>().name) != "" &&
            PlayerPrefs.GetString("achi" + image[8].GetComponent<Image>().name) != "" &&
            PlayerPrefs.GetString("achi" + image[7].GetComponent<Image>().name) != "" &&
            PlayerPrefs.GetString("achi" + image[6].GetComponent<Image>().name) != "" &&
            PlayerPrefs.GetString("achi" + image[5].GetComponent<Image>().name) != "" &&
            PlayerPrefs.GetString("achi" + image[4].GetComponent<Image>().name) != "" &&
            PlayerPrefs.GetString("achi" + image[3].GetComponent<Image>().name) != "" &&
            PlayerPrefs.GetString("achi" + image[2].GetComponent<Image>().name) != "" &&
            PlayerPrefs.GetString("achi" + image[1].GetComponent<Image>().name) != "")
        {
            whichAchi = 22;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "The god,Complete 100% game," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        if (PlayerPrefs.GetString("achi" + image[23].GetComponent<Image>().name) == "" &&
            PlayerPrefs.GetString("achi" + image[22].GetComponent<Image>().name) != "" &&
            PlayerPrefs.GetString("achi" + image[21].GetComponent<Image>().name) != "" &&
            PlayerPrefs.GetString("achi" + image[20].GetComponent<Image>().name) != "")
        {
            whichAchi = 21;
            achiMask.gameObject.SetActive(true);
            image[whichAchi].gameObject.SetActive(true);
            PlayerPrefs.SetString("achi" + image[whichAchi].GetComponent<Image>().name, "The real god,Complete 103% game," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }
    }
}
