using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportDisableCollider : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerRigidbody;  // Αναφορά στο Rigidbody του παίκτη

    [SerializeField]
    private GameObject Sphere;

    [SerializeField]
    private string targetTag = "TeleportTarget";  // Το tag που πρέπει να έχει το αντικείμενο για να ενεργοποιηθεί το Rigidbody

    private TeleportationProvider teleportationProvider;

    private void Start()
    {
        // Βρίσκουμε τον TeleportationProvider στην σκηνή
        teleportationProvider = FindObjectOfType<TeleportationProvider>();

        if (teleportationProvider == null)
        {
            Debug.LogError("TeleportationProvider not found in the scene.");
            return;
        }

        // Σιγουρεύουμε ότι το Rigidbody του παίκτη έχει αρχικά απενεργοποιημένη τη φυσική (για το teleport)
        if (playerRigidbody == null)
        {
            Debug.LogError("Player Rigidbody not assigned.");
        }
        else
        {
            // Αρχικά απενεργοποιούμε τη βαρύτητα και το kinematic, ώστε να μην έχει φυσική αλληλεπίδραση πριν το teleport
            playerRigidbody.useGravity = false;
            playerRigidbody.isKinematic = true;
        }

        // Συνδέουμε το event για την ολοκλήρωση της μετακίνησης (teleport)
        teleportationProvider.endLocomotion += OnTeleportCompleted;
    }

    // Αυτή η μέθοδος καλείται όταν ολοκληρωθεί το teleport
    private void OnTeleportCompleted(LocomotionSystem locomotionSystem)
    {
        // Χρησιμοποιούμε Raycast για να βρούμε το αντικείμενο κάτω από τον παίκτη
        RaycastHit hit;
        Vector3 playerPosition = locomotionSystem.xrOrigin.Camera.transform.position;

        if (Physics.Raycast(playerPosition, Vector3.down, out hit, Mathf.Infinity))
        {
            Collider hitCollider = hit.collider;

            // Ελέγχουμε αν το αντικείμενο έχει το συγκεκριμένο tag
            if (hitCollider != null && hitCollider.CompareTag(targetTag))
            {
                // Αν το αντικείμενο έχει το σωστό tag, απενεργοποιούμε το collider του και ενεργοποιούμε το Rigidbody
                hitCollider.enabled = false;

                Sphere.SetActive(false);

                Debug.Log("Collider disabled on object with tag: " + hitCollider.gameObject.name);

                // Ενεργοποιούμε τη φυσική στο Rigidbody του παίκτη
                if (playerRigidbody != null)
                {
                    playerRigidbody.useGravity = true;
                    playerRigidbody.isKinematic = false;  // Απενεργοποιούμε το kinematic για να δουλέψει η βαρύτητα

                    // Περιορίζουμε την περιστροφή
                    playerRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                }
            }
            else
            {
                // Αν το αντικείμενο ΔΕΝ έχει το tag, αφήνουμε το Rigidbody ανενεργό (χωρίς βαρύτητα)
                if (playerRigidbody != null)
                {
                    playerRigidbody.useGravity = false;
                    playerRigidbody.isKinematic = true;  // Παραμένει kinematic για να μην αλληλεπιδρά με τη φυσική
                    Debug.Log("Teleport completed but no valid targetTag found.");
                }
            }
        }
    }

    private void OnDestroy()
    {
        // Αφαιρούμε το event listener όταν καταστραφεί το αντικείμενο
        if (teleportationProvider != null)
        {
            teleportationProvider.endLocomotion -= OnTeleportCompleted;
        }
    }
}