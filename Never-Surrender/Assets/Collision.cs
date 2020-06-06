using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    private bool playerInZone;
    private GameObject player;
    public string levelName;
    private float playerX;
    private float playerY;

    public ParticleSystem splatParticles;
    public GameObject splatPrefab;
    public Transform splatHolder;
    public AudioSource audio;
    public AudioClip death;


    void Start()
    {
        playerInZone = false;
        player = GameObject.Find("Player");
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
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
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            CastRay();
            audio.PlayOneShot(death);
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
