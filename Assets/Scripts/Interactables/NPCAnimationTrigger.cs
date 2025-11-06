using UnityEngine;

public class NPCAnimationTriggerWithGameObject : MonoBehaviour
{
    // Reference to the GameObject that has the Animator component and animation
    [SerializeField] private GameObject npcWithAnimation;

    // Name of the animation to play
    [SerializeField] private string animationName = "YourAnimationName"; // Set this in the Inspector

    private Animator npcAnimator;

    // Start is called before the first frame update
    void Start()
    {
        if (npcWithAnimation == null)
        {
            Debug.LogError("No GameObject assigned. Please assign the GameObject with the Animator component.");
            return;
        }

        // Get the Animator component from the assigned GameObject
        npcAnimator = npcWithAnimation.GetComponent<Animator>();

        if (npcAnimator == null)
        {
            Debug.LogError("No Animator component found on the assigned GameObject.");
            return;
        }

        // Play the animation when the scene starts
        PlayAnimation();
    }

    // This method triggers the animation
    public void PlayAnimation()
    {
        if (npcAnimator != null && !string.IsNullOrEmpty(animationName))
        {
            npcAnimator.Play(animationName);
        }
        else
        {
            Debug.LogError("Animator component is missing or animation name is not set.");
        }
    }
}