using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pinakas1D : MonoBehaviour
{
    [SerializeField]
    private GameObject key;
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private GameObject previus;
    private bool doorOpen;

    [SerializeField]
    private AudioSource audioSource; // Το AudioSource που θα παίζει τα κλιπ

    public static int interactedCubesCount = 0;
    
    // Χρησιμοποιούμε το Collider του αντικειμένου για να ανιχνεύσουμε την επαφή με το χέρι του παίκτη
    private void OnTriggerEnter(Collider other)
    {
        // Έλεγχος αν το αντικείμενο που αλληλεπιδρά είναι τα χέρια του παίκτη (μπορείς να χρησιμοποιήσεις ένα tag ή layer για έλεγχο)
        if (other.CompareTag("PlayerHand"))
        {   
            // Έλεγχος σωστής σειράς επιλογών
            if (!previus.activeSelf){
                interactedCubesCount++;
                key.SetActive(false);
                audioSource.Play();
                CheckInteractedCubes();
            }else{
                string currentSceneName = SceneManager.GetActiveScene().name;
                // Επαναφορτώνουμε τη σκηνή
                SceneManager.LoadScene(currentSceneName);
            }
        }
    }

    void CheckInteractedCubes()
    {
        if (interactedCubesCount >= 5)
        {
            interactedCubesCount = 0;
            doorOpen = !doorOpen;
            door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
        }
    }
}
