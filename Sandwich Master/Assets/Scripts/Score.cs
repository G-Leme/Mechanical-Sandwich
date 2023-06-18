using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;

    public static Score Instance;
    public TextMeshProUGUI finalScoreUI;

    void Awake()
    {
        Instance = this; 
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
