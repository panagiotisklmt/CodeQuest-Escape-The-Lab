using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public string scenename;
    public void Load(){
        SceneManager.LoadScene(scenename);
    }
}
