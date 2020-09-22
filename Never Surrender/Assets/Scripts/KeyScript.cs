using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Config;

public class KeyScript : MonoBehaviour
{
    [SerializeField]
    private float speedRotate;
    [SerializeField]
    private float speedFloating;
    private Vector2 fly;
    private Vector2 originPos;
    public static bool collected = Config.collected;
    private Transform target;
    private float speed = 15;
    public GameObject entry, exit, doorLock;
    // Start is called before the first frame update
    void Start()
    {
        originPos = this.transform.position;
        target = GameObject.Find("Player").GetComponent<Transform>();
        StartCoroutine(Spinning(4f));
    }

    // Update is called once per frame
    void Update()
    {
        fly = transform.position;
        transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
        
        if(collected)
        {
            if (Vector2.Distance(transform.position, target.position) > 5)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            exit.gameObject.SetActive(true);
            entry.gameObject.SetActive(false);
            doorLock.gameObject.SetActive(false);
        }
        else
        {
            fly.y = (originPos.y + Mathf.Sin(Time.time) * speedFloating);
            fly.x = originPos.x;
            transform.position = fly;
            entry.gameObject.SetActive(true);
            exit.gameObject.SetActive(false);
            doorLock.gameObject.SetActive(true);
        }
    }
    IEnumerator Spinning(float time)
    {
        yield return new WaitForSeconds(time);
        speedRotate *= -1;
        StartCoroutine(Spinning(8f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
            collected = true;
    }
}
