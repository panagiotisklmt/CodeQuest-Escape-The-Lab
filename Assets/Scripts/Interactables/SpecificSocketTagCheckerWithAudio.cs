using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SpecificSocketTagCheckerWithAudio : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor socket1;  // Reference to the first socket
    [SerializeField] private XRSocketInteractor socket2;  // Reference to the second socket
    [SerializeField] private XRSocketInteractor socket3;  // Reference to the third socket
    [SerializeField] private GameObject uiComponents;     // The UI Components object to show
    [SerializeField] private AudioSource audioSource;     // The AudioSource to play a sound when all objects are correct

    private void Start()
    {
        // Initially hide the UI Components and ensure the AudioSource is assigned
        if (uiComponents != null)
        {
            uiComponents.SetActive(false);
        }
        else
        {
            Debug.LogError("UI Components GameObject is not assigned.");
        }

        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not assigned.");
        }

        // Subscribe to the select and deselect events of each socket
        socket1.selectEntered.AddListener(OnSocketUpdated);
        socket1.selectExited.AddListener(OnSocketUpdated);
        socket2.selectEntered.AddListener(OnSocketUpdated);
        socket2.selectExited.AddListener(OnSocketUpdated);
        socket3.selectEntered.AddListener(OnSocketUpdated);
        socket3.selectExited.AddListener(OnSocketUpdated);
    }

    private void OnDestroy()
    {
        // Unsubscribe from the events to prevent memory leaks
        socket1.selectEntered.RemoveListener(OnSocketUpdated);
        socket1.selectExited.RemoveListener(OnSocketUpdated);
        socket2.selectEntered.RemoveListener(OnSocketUpdated);
        socket2.selectExited.RemoveListener(OnSocketUpdated);
        socket3.selectEntered.RemoveListener(OnSocketUpdated);
        socket3.selectExited.RemoveListener(OnSocketUpdated);
    }

    // This method is called when an object is placed in or removed from any socket
    private void OnSocketUpdated(SelectEnterEventArgs args) => CheckSockets();
    private void OnSocketUpdated(SelectExitEventArgs args) => CheckSockets();

    private void CheckSockets()
    {
        // Check if each socket contains the object with the correct tag
        bool allCorrect = IsCorrectObjectInSocket(socket1, "Correct1") 
                       && IsCorrectObjectInSocket(socket2, "Correct2") 
                       && IsCorrectObjectInSocket(socket3, "Correct3");

        // Show or hide the UI Components based on the condition
        if (allCorrect)
        {
            if (!uiComponents.activeSelf)  // Only play sound if UI was previously hidden
            {
                uiComponents.SetActive(true);
                if (audioSource != null)
                {
                    audioSource.Play();  // Play the sound
                }
                Debug.Log("All sockets have the correct objects. UI Components enabled.");
            }
        }
        else
        {
            uiComponents.SetActive(false);
            Debug.Log("Not all sockets have the correct objects. UI Components hidden.");
        }
    }

    private bool IsCorrectObjectInSocket(XRSocketInteractor socket, string requiredTag)
    {
        // Check if the socket has an object with the specified tag
        if (socket.hasSelection)
        {
            var selectedInteractable = socket.GetOldestInteractableSelected();
            if (selectedInteractable != null)
            {
                GameObject selectedObject = selectedInteractable.transform.gameObject;
                return selectedObject.CompareTag(requiredTag);
            }
        }
        return false;
    }
}