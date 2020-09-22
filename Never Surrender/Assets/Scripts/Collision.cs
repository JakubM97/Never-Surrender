using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.ComponentModel;
using static PlayerScript;
using static KeyScript;
using static ConsoleScript;

public class Collision : MonoBehaviour
{
    private bool playerInZone;
    private GameObject player;
    public string levelName;
    public ParticleSystem splatParticles;
    public GameObject splatPrefab;
    public Transform splatHolder;
    public AudioSource audio;
    public AudioClip death;
    private bool hesdead = false;

    void Start()
    {
        try
        {
            playerInZone = false;
            player = GameObject.Find("Player");
            audio = GameObject.Find("Player").GetComponent<AudioSource>();
            splatParticles = GameObject.Find("Splat Particles").GetComponent<ParticleSystem>();
            splatHolder = GameObject.Find("Splat Holder").GetComponent<Transform>();
        }
        catch (NullReferenceException e)
        {

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerInZone)
        {
            if (levelName == "Level1_1")
            {
                player.transform.position = new Vector3(-55, -19, 0);
            }
            if (levelName == "Level3")
            {
                player.transform.position = new Vector3(-55, 32, 0);
            }
            KeyScript.collected = false;
            PlayerScript.deathCount++;
            PlayerPrefs.SetInt("Death", PlayerScript.deathCount);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && hesdead == false && this.name != "Lava" && !ConsoleScript.tgm)
        {
            hesdead = true;
            CastRay();
            playerInZone = true;
            audio.PlayOneShot(death);
            GameObject.Find("SavedGame").GetComponent<SavedData>().playerHealth--;
            PlayerPrefs.SetInt(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave.ToString() + "HP", GameObject.Find("SavedGame").GetComponent<SavedData>().playerHealth);
            if (this.gameObject.tag == "Saw")
            {
                PlayerScript.deathBySaw++;
                PlayerPrefs.SetInt("DeathBySaw", PlayerScript.deathBySaw);
            }
            if (this.gameObject.tag == "Spike")
            {
                PlayerScript.deathBySpike++;
                PlayerPrefs.SetInt("DeathBySpike", PlayerScript.deathBySpike);
            }
            if (this.gameObject.tag == "Tesla")
            {
                PlayerScript.deathByTesla++;
                PlayerPrefs.SetInt("DeathByTesla", PlayerScript.deathByTesla);
            }
            if (this.gameObject.tag == "Bullet")
            {
                PlayerScript.deathByBullet++;
                PlayerPrefs.SetInt("DeathByBullet", PlayerScript.deathByBullet);
            }
            if (this.gameObject.tag == "Slime")
            {
                PlayerScript.deathBySlime++;
                PlayerPrefs.SetInt("DeathBySlime", PlayerScript.deathBySlime);
            }
        }
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player" && !ConsoleScript.tgm)
        {
            playerInZone = false;
            hesdead = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player" && hesdead == false && PlayerScript.color.a >= 0.65f && !ConsoleScript.tgm)
        {
            hesdead = true;
            CastRay();
            playerInZone = true;
            audio.PlayOneShot(death);
            GameObject.Find("SavedGame").GetComponent<SavedData>().playerHealth--;
            PlayerPrefs.SetInt(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave.ToString() + "HP", GameObject.Find("SavedGame").GetComponent<SavedData>().playerHealth);
            if (this.gameObject.tag == "Lava")
            {
                PlayerScript.deathByLava++;
                PlayerPrefs.SetInt("DeathByLava", PlayerScript.deathByLava);
            }

        }
    }
    private void CastRay()
    {
        GameObject splat = Instantiate(splatPrefab, player.transform.position, Quaternion.identity);
        splat.transform.SetParent(splatHolder, true);
        Splat splatScript = splat.GetComponent<Splat>();
        splatParticles.transform.position = player.transform.position;
        splatParticles.Play();
        splatScript.Initialized(Splat.SplatLocation.Background);

    }
}
