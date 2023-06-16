using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    private float delay;

    public float timer;
    void Start()
    {
        delay = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (delay >= 0)
        {
            delay = delay -= Time.deltaTime;
        }

        if (delay <= 0)
        {
            if (timer >= 0)
                timer = timer -= Time.deltaTime;

            timerText.text = ("Time: " + timer.ToString("0"));
        }
    }
}
