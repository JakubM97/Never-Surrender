using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;

    public Animator anim;

    private bool movingRight = true;

    public Transform groundDetection;

    private void Start()
    {

    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.length * (anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1) * anim.GetCurrentAnimatorClipInfo(0)[0].clip.frameRate > 7)
        {
            speed = 1;
        }
        else speed = 10;
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f);

        if(groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

}
