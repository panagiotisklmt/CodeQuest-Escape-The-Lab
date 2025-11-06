using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreBoard : MonoBehaviour
{
    public Text ScoreText;
    String s;
    String s1;
    private ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }


    // Update is called once per frame
    void Update()
    {
        int currentScore = scoreManager.GetScore();
        currentScore = 100 - currentScore;
        if(currentScore >= 100 && currentScore >= 90 ){
            s1 = "Excelent you are ready to pass the semester!";
        }else if(currentScore <= 89 && currentScore >= 70 ){
            s1 = "Prety good with some training you can get perfect at C";
        }else if(currentScore <= 69 && currentScore >= 50 ){
            s1 = "You did okay but you can definately do better next time";
        }else if(currentScore <= 49 && currentScore >= 1 ){
            s1 = "You have to practice more!!";
        }
        s = currentScore.ToString();
        ScoreText.text =  s + "\n" + s1;
    }
}
