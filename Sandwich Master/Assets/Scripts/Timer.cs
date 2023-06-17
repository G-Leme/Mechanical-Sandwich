using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private AudioSource timeAudio;

    private float delay;

    public float timer;
    void Start()
    {
        delay = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer <= 30 && timer >= 29.5f)
        {
            timeAudio.Play();
        }

        if (timer <= 10 && timer >= 9.5f)
            timeAudio.Play();


        if (delay >= 0)
        {
            delay = delay -= Time.deltaTime;
        }

        if (delay <= 0)
        {
            if (timer >= 0)
                timer = timer -= Time.deltaTime;

            timerText.text = (timer.ToString("0"));
        }
    }
}
