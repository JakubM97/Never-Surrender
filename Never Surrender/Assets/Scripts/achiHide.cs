using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class achiHide : MonoBehaviour
{
    public Color color1;
    private string sceneName;
    public GameObject achiMask;

    // Update is called once per frame
    void FixedUpdate()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        color1.a -= 0.15f * Time.deltaTime;
        this.gameObject.GetComponent<Image>().color = color1;
        if(this.gameObject.GetComponent<Image>().color.a < 0.02f)
        {
            this.gameObject.SetActive(false);
        }
        if (sceneName == "Menu")
        {
            this.gameObject.GetComponent<Image>().color = new Vector4(1f, 1f, 1f, 0f);
            this.gameObject.SetActive(false);
            achiMask.SetActive(false);
        }
    }
    
}
