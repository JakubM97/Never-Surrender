using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    private Color color;
    private void Update()
    {
        
        if (PlayerPrefs.GetFloat("achi" + this.gameObject.name) != 0 || PlayerPrefs.GetInt("achi" + this.gameObject.name) != 0 || PlayerPrefs.GetString("achi" + this.gameObject.name) != "")
        {
            if (this.gameObject.name == "21")
            {
                this.gameObject.SetActive(true);
            }
            if (this.gameObject.name == "22")
            {
                this.gameObject.SetActive(true);
            }
            color = new Vector4(1f, 1f, 1f, 1f);
            this.gameObject.GetComponent<Image>().color = color;
            this.gameObject.GetComponent<Button>().interactable = true;
            
        }
        else
        {
            if (this.gameObject.name == "21")
            {
                this.gameObject.SetActive(false);
            }
            if (this.gameObject.name == "22")
            {
                this.gameObject.SetActive(false);
            }
            color = new Vector4(1f, 1f, 1f, 0.3f);
            this.gameObject.GetComponent<Image>().color = color;
            this.gameObject.GetComponent<Button>().interactable = false;
        }
        
    }
}
