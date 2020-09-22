using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Config : MonoBehaviour
{
    public static int whichSave = 1;
    public static int whichLevel = 1;
    public static string[] levels = {
        "Level1_1", "Level1_2", "Level1_3", "Level1_4",
        "Level2_1", "Level2_2", "Level2_3", "Level2_4",
        "Level3_1", "Level3_2", "Level3_3", "Level3_4"};
    public static bool isUnlocked = true;
    public static bool speedrun = false;
    public static float time = 0f;
    public static float startTime = 0f;
    public static float sawSpeed = 0.25f;
    public static int sawMaxLimite = 5;
    public static string difficulty = "Normal";
    public static int playerHealth = -1;
    public static bool gameOver = false;
    public static float jumpForce = 45;
    public static bool collected = false;
}
