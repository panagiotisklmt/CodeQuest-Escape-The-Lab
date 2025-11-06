using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chapters_Scene : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject ScenesMenu;

    [Header("Scenes Buttons")]
    public Button Chapter1;
    public Button Chapter2;
    public Button Chapter3;
    public Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        EnableMainMenu();

        //Hook events
        Chapter1.onClick.AddListener(StartChapter1);
        Chapter2.onClick.AddListener(StartChapter2);
        Chapter3.onClick.AddListener(StartChapter3);
        backButton.onClick.AddListener(GoBack);
    }

    public void GoBack()
    {
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(0);
    }

    public void StartChapter1()
    {
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(3);
    }

    public void StartChapter2()
    {
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(4);
    }

    public void StartChapter3()
    {
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(5);
    }

    public void HideAll()
    {
        ScenesMenu.SetActive(false);
    }

    public void EnableMainMenu()
    {
        ScenesMenu.SetActive(true);
    }
}
