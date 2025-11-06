using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeypadBlue : Interactable
{
   

    public string sceneToLoad;

    protected override void Interact()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnEnable(){
        narkalieftis.interactedCubesCount = 0;
    }
}
