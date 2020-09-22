using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            GameObject.Find("SavedGame").GetComponent<SavedData>().coinCollected = true;
            Destroy(this.gameObject);
        }
    }
}
