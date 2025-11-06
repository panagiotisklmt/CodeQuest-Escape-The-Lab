using UnityEngine;
using UnityEngine.SceneManagement;

public class WrongObjectInteraction : MonoBehaviour
{

    [SerializeField]
    private AudioSource audioSource; // Το AudioSource που θα παίζει τα κλιπ

    [SerializeField]
    private AudioClip buttonPressClip; // Ήχος όταν πατηθεί το κουμπί

    // Χρησιμοποιούμε το Collider του αντικειμένου για να ανιχνεύσουμε την επαφή με το χέρι του παίκτη
    private void OnTriggerEnter(Collider other)
    {
        // Έλεγχος αν το αντικείμενο που αλληλεπιδρά είναι τα χέρια του παίκτη (μπορείς να χρησιμοποιήσεις ένα tag ή layer για έλεγχο)
        if (other.CompareTag("PlayerHand"))
        {
            audioSource.Play();
            Invoke("ReloadScene",buttonPressClip.length);           
        }
    }

     private void ReloadScene()
    {
        // Παίρνουμε το όνομα της τρέχουσας σκηνής
        string currentSceneName = SceneManager.GetActiveScene().name;
    
        // Επαναφορτώνουμε τη σκηνή
        SceneManager.LoadScene(currentSceneName);
    }
}