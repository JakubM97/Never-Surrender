using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConsoleScript;

public class squeeze : MonoBehaviour
{
    public float vel, tempvel;
    private bool squeeze1 = false, squeeze2 = false, player = false, squeeze0 = false, hesdead = false, playerInZone = false;
    private GameObject playerGO;
    public string levelName;

    public ParticleSystem splatParticles;
    public GameObject splatPrefab;
    public Transform splatHolder;
    public AudioSource audio;
    public AudioClip death;
    public ParticleSystem sparks;
    // Start is called before the first frame update
    void Start()
    {
        playerGO = GameObject.Find("Player");
        tempvel = vel;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(vel, 0);

        
        if (playerInZone)
        {
            if (levelName == "Level1_1")
            {
                playerGO.transform.position = new Vector3(-55, -19, 0);
                hesdead = false;
                playerInZone = false;
            }
            if (levelName == "Level3")
            {
                playerGO.transform.position = new Vector3(-55, 32, 0);
            }
            PlayerScript.deathCount++;
            PlayerPrefs.SetInt("Death", PlayerScript.deathCount);
        }
    }
    private void Update()
    {
        if (hesdead == false && player && squeeze1 && !ConsoleScript.tgm)
        {
            hesdead = true;
            CastRay();
            playerInZone = true;
            audio.PlayOneShot(death);
            GameObject.Find("SavedGame").GetComponent<SavedData>().playerHealth--;
            PlayerPrefs.SetInt(GameObject.Find("SavedGame").GetComponent<SavedData>().whichSave.ToString() + "HP", GameObject.Find("SavedGame").GetComponent<SavedData>().playerHealth);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "squeeze1")
        {
            squeeze0 = true;
            squeeze1 = true;
            sparks.Play();
            StartCoroutine(WaitClose(1.5f));
            vel = 0;
        }
        if (collision.name == "squeeze2")
        {
            squeeze0 = true;
            squeeze2 = true;
            StartCoroutine(WaitClose(1.5f));
            vel = 0;
        }
        if (collision.name == "Player")
        {
            player = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "squeeze1")
        {
            squeeze0 = false;
            squeeze1 = false;
            StartCoroutine(WaitOpen(2));
            StartCoroutine(StopReturn(0.4f));
        }
        if (collision.name == "squeeze2")
        {
            squeeze0 = false;
            squeeze2 = false;
            StartCoroutine(WaitOpen(2));
            StartCoroutine(StopReturn(0.4f));
        }
        if (collision.name == "Player")
        {
            player = false;
        }
    }
    private void CastRay()
    {
        GameObject splat = Instantiate(splatPrefab, playerGO.transform.position, Quaternion.identity);
        splat.transform.SetParent(splatHolder, true);
        Splat splatScript = splat.GetComponent<Splat>();
        splatParticles.transform.position = playerGO.transform.position;
        splatParticles.Play();
        splatScript.Initialized(Splat.SplatLocation.Background);

    }
    IEnumerator WaitClose(float time)
    {
        yield return new WaitForSeconds(time);
        vel = tempvel;
        vel = vel / 2 * (-1);
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(vel, 0);
        
    }
    IEnumerator WaitOpen(float time)
    {
        yield return new WaitForSeconds(time);
        vel = tempvel;
        
    }
    IEnumerator StopReturn(float time)
    {
        yield return new WaitForSeconds(time);
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        vel = 0;
        
    }
}
