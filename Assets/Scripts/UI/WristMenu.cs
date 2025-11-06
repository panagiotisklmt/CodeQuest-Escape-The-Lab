using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WristMenu : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject scrollview;
    public GameObject mainMenu;
    public GameObject helpButton;
    public GameObject quitButton;
    public GameObject backButton;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        SceneTransitionManager.singleton.GoToSceneAsync(0);
    }
    
    public void GoToHelp()
    {
        HideAll();
        backButton.SetActive(true);
        scrollview.SetActive(true);
    }


    public void HideAll()
    {
        mainMenu.SetActive(false);
        helpButton.SetActive(false);
        quitButton.SetActive(false);
    }


    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        helpButton.SetActive(true);
        quitButton.SetActive(true);
    }

    public void backToWrist()
    {
        backButton.SetActive(false);
        scrollview.SetActive(false);
        EnableMainMenu();
    }
}
