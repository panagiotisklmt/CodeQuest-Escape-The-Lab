using UnityEngine;

public class ScoringItem : Interactable
{

    private ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    protected override void Interact(){
        scoreManager.IncreaseScore(2);
        int currentScore = scoreManager.GetScore();
        Debug.Log(currentScore);
    }
}
