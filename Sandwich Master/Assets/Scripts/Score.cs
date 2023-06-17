using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;

    public static Score Instance;
    [SerializeField] private TextMeshProUGUI finalScore;

    void Awake()
    {
        Instance = this; 
    }

    // Update is called once per frame
    void Update()
    {
       finalScore.text = ("SCORE:" + score.ToString());
    }
}
