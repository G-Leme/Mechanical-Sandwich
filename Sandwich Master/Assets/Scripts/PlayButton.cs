using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject game;
    [SerializeField] private Button buttonPlay;
    private void Awake()
    {
        buttonPlay.onClick.AddListener(OnButtonPlayClick);
    }

    private void OnButtonPlayClick()
    {
        mainMenu.SetActive(false);
        game.SetActive(true);
    }

}
