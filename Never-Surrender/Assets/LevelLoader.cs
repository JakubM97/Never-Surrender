using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Text timerText;
    public int[,] HighScore = new int[12,3];
    private bool playerInZone;
    public string levelToLoad;
    private float startTime;
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
        if(playerInZone)
        {
            SceneManager.LoadScene(levelToLoad);
        }
        t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerText.text = minutes + ":" + seconds;
        if (player != null && this != null)
        {
            if (Vector2.Distance(player.transform.position, this.transform.position) < 35 )
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
        if (PlayerPrefs.GetFloat(levelName + "Best") > t || PlayerPrefs.GetFloat(levelName + "Best") == 0)
        {
            PlayerPrefs.SetFloat(levelName + "Best", t);
        }
        if (collision.name == "Player")
        {
            playerInZone = true;
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
