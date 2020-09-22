using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockSecret : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("SavedGame").GetComponent<SavedData>().secret = true;
    }

}
