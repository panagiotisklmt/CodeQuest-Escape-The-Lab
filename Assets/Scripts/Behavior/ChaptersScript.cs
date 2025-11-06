using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChaptersScript : MonoBehaviour
{
    public void PlayChap1(){
        SceneManager.LoadScene("Level1");
    }

    public void PlayChap2(){
        SceneManager.LoadScene("Level2");
    }

   public void PlayChap3(){
        SceneManager.LoadScene("Level3");
    }

    public void GoBack(){
        SceneManager.LoadScene("MainMenu");
    }

}