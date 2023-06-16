using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
  
    [SerializeField] TextMeshProUGUI countdownText;

    public float countdown;
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void FixedUpdate()
    {
        if (countdownText.text != ("GO"))
        {
            countdown = countdown -= Time.deltaTime;
            countdownText.text = (countdown.ToString("0"));
        }

        if(countdown <= 0.5)
        {
            countdownText.text = ("GO");
            countdownText.alpha -= 0.015f;
        }

    }
}
