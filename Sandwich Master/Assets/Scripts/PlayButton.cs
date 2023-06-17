using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject game;
    [SerializeField] private Button buttonPlay;
    [SerializeField] private Button buttonPlayAgain;
    private void Awake()
    {
        buttonPlay.onClick.AddListener(OnButtonPlayClick);
        buttonPlayAgain.onClick.AddListener(OnButtonReplayClick);
    }

    private void OnButtonPlayClick()
    {
        mainMenu.SetActive(false);
        game.SetActive(true);
    }

    private void OnButtonReplayClick()
    {
        SceneManager.LoadScene("MainGame");
    }

}
