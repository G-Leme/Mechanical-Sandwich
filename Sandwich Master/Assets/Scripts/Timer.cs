using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private AudioSource timeAudio;
    [SerializeField] private GameObject timeUpUI;
    [SerializeField] private GameObject playAgainMenu;
    [SerializeField] private GameObject playAgainButton;

    [SerializeField] private GameObject Image;

    private float delay;

    public float timer;
    void Start()
    {
        delay = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
   
        if (timer <= 0)
        {
            timeUpUI.SetActive(true);
           StartCoroutine(EnableScoreUI());
        }

        if (timer <= 30 && timer >= 29.5f)
            timeAudio.Play();
        

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

    IEnumerator EnableScoreUI()
    {
        yield return new WaitForSeconds(2f);
        playAgainMenu.transform.position = new Vector3(0, 0, 0);
        playAgainButton.SetActive(true);
        Image.SetActive(false);
        Score.Instance.finalScoreUI.text = ("SCORE: " + Score.Instance.score.ToString()); 
     
    }
}
