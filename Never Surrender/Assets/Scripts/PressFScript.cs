using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressFScript : MonoBehaviour
{
    public AudioClip coin;
    public AudioSource audioSource;
    private void Start()
    {
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            if(Input.GetKeyDown(KeyCode.F) && GameObject.Find("SavedGame").GetComponent<SavedData>().coinCollected == true)
            {
                GameObject.Find("SavedGame").GetComponent<SavedData>().secretUnlocked = true;
                audioSource.PlayOneShot(coin);
                GameObject.Find("SavedGame").GetComponent<SavedData>().coinCollected = false;
            }
        }
    }
}
