using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NPCXRClickWithAudioCooldown : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // Audio source for Kyle's voice
    [SerializeField] private AudioSource backgroundMusicSource; // Audio source for background music
    [SerializeField] private float backgroundMusicVolumeDuringKyle = 0.3f; // Volume level for background music while Kyle's audio is playing

    private XRBaseInteractable interactable;
    private float originalBackgroundMusicVolume;

    private void OnEnable()
    {
        interactable = GetComponent<XRBaseInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnSelectEntered);
        }
        else
        {
            Debug.LogError("No XRBaseInteractable found on the NPC.");
        }

        // Store the original volume of the background music
        if (backgroundMusicSource != null)
        {
            originalBackgroundMusicVolume = backgroundMusicSource.volume;
        }
    }

    private void OnDisable()
    {
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnSelectEntered);
        }
    }

    // Method called when the NPC is clicked or interacted with
    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Kyle NPC clicked (via XR Interactor)!");

        // Play the audio clip if AudioSource is assigned, not already playing, and interaction is allowed
        if (audioSource != null && !audioSource.isPlaying)
        {
            // Disable interaction while the audio is playing
            interactable.enabled = false;

            // Lower the background music volume
            if (backgroundMusicSource != null)
            {
                backgroundMusicSource.volume = backgroundMusicVolumeDuringKyle;
            }

            // Play Kyle's audio
            audioSource.Play();

            // Re-enable interaction after the audio finishes
            Invoke(nameof(EnableInteraction), audioSource.clip.length);
        }
        else if (audioSource != null && audioSource.isPlaying)
        {
            Debug.Log("Audio is still playing. Interaction is temporarily disabled.");
        }
        else
        {
            Debug.LogError("AudioSource is either missing or already playing.");
        }
    }

    // Method to re-enable interaction and restore background music volume
    private void EnableInteraction()
    {
        interactable.enabled = true;

        // Restore the original background music volume
        if (backgroundMusicSource != null)
        {
            backgroundMusicSource.volume = originalBackgroundMusicVolume;
        }

        Debug.Log("Interaction with Kyle re-enabled.");
    }
}