using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisappearBlock : MonoBehaviour
{
    public GameObject player;
    private Color c = new Vector4(1,1,1,1);
    private bool playerOnBlock = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!playerOnBlock)
        {
            c.a = (Vector2.Distance(player.gameObject.transform.position, this.gameObject.transform.position) - 30) / 100;
        }
        this.GetComponent<SpriteRenderer>().color = c;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "Player")
        {
            playerOnBlock = true;
            c.a = 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            playerOnBlock = false;
            
        }
    }
}
