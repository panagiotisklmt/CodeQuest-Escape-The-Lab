using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Keyboard : Interactable
{
    public string sceneToLoad;
    protected override void Interact()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}




