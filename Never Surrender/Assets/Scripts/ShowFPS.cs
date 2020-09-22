using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowFPS : MonoBehaviour
{
    public float deltaTime, show = 0;

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        if(show>200)
        {
            this.gameObject.GetComponent<TMP_Text>().text = Mathf.Ceil(fps).ToString();
            show = 0;
        }
        show++;
    }
}
