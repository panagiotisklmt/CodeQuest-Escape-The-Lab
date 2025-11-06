using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Abyss : MonoBehaviour
{
    public string scenename;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("PlayerHand")){
            SceneManager.LoadScene(scenename);
        }
    }
}
