using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score;

    // Καλείται όταν η σκηνή ξεκινάει
    private void Start()
    {
        // Φόρτωση του score από τις PlayerPrefs
        score = PlayerPrefs.GetInt("Score", 0);
    }

    // Καλείται για να αυξήσει το score
    public void IncreaseScore(int amount)
    {
        score += amount;
        SaveScore();
    }

    // Καλείται για να αποθηκεύσει το score στις PlayerPrefs
    private void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
    }

    // Καλείται για να διαγράψει το score από τις PlayerPrefs
    public void ResetScore()
    {
        score = 0;
        PlayerPrefs.DeleteKey("Score");
        SaveScore();
    }

    // Επιστρέφει το τρέχον score
    public int GetScore()
    {
        return score;
    }

}