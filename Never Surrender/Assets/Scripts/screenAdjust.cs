using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenAdjust : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        Camera.main.aspect = 1920f / 1080f;
    }
}
