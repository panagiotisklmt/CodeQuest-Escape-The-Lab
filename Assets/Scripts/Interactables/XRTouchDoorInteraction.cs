using UnityEngine;

public class XRTouchDoorInteraction : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The door object that will open when the player touches this object")]
    private GameObject door;

    [SerializeField]
    private AudioSource audioSource; // Το AudioSource που θα παίζει τα κλιπ

    private bool doorOpen = false;

    // Χρησιμοποιούμε το Collider του αντικειμένου για να ανιχνεύσουμε την επαφή με το χέρι του παίκτη
    private void OnTriggerEnter(Collider other)
    {
        // Έλεγχος αν το αντικείμενο που αλληλεπιδρά είναι τα χέρια του παίκτη (μπορείς να χρησιμοποιήσεις ένα tag ή layer για έλεγχο)
        if (other.CompareTag("PlayerHand"))
        {
            audioSource.Play();
            OpenDoor();  // Κλήση της μεθόδου για άνοιγμα της πόρτας
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Όταν ο παίκτης βγει από την περιοχή του αντικειμένου, κλείσε την πόρτα
        if (other.CompareTag("PlayerHand"))
        {
            Invoke("CloseDoor", 10f);  // Κλείσιμο της πόρτας μετά από 3 δευτερόλεπτα
        }
    }

    // Άνοιγμα της πόρτας
    private void OpenDoor()
    {
        if (!doorOpen)
        {
            doorOpen = true;
            door.GetComponent<Animator>().SetBool("IsOpen", true);  // Χρήση του Animator για άνοιγμα της πόρτας
        }
    }

    // Κλείσιμο της πόρτας
    private void CloseDoor()
    {
        if (doorOpen)
        {
            doorOpen = false;
            door.GetComponent<Animator>().SetBool("IsOpen", false);  // Κλείσιμο της πόρτας
        }
    }
}