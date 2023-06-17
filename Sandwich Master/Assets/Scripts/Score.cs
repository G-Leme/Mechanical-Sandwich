using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int finalScore;
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
