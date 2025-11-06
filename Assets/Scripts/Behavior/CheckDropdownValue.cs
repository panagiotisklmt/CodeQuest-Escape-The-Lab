using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckDropdownValue : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;           // Reference to the TMP Dropdown
    [SerializeField] private TextMeshProUGUI resultText;      // Reference to the TMP Text for displaying results
    [SerializeField] private AudioSource correctAudio;        // Audio source for the correct answer
    [SerializeField] private AudioSource incorrectAudio;      // Audio source for the incorrect answer
    [SerializeField] private GameObject door;                 // Door to be opened
    [SerializeField] private Button validateButton;           // Reference to the Button for validation
    private Animator doorAnimator;                            // Animator for door if needed

    private void Start()
    {
        // Ensure the door has an animator if it uses one for opening
        if (door != null)
        {
            doorAnimator = door.GetComponent<Animator>();
        }

        // Attach the OnValidateButtonClick method to the button's onClick event
        if (validateButton != null)
        {
            validateButton.onClick.AddListener(OnValidateButtonClick);
        }
    }

    // This method can be connected to the button's OnClick event
    public void OnValidateButtonClick()
    {
        // Parse the selected dropdown text value
        float selectedValue;
        bool isParsed = float.TryParse(dropdown.options[dropdown.value].text, out selectedValue);

        if (isParsed && Mathf.Approximately(selectedValue, 0.974370f)) // Check if value is approximately 0.974370
        {
            // Play correct audio
            if (correctAudio != null)
                correctAudio.Play();

            // Display "Correct" in the resultText
            if (resultText != null)
                resultText.text = "Correct";

            // Open the door (using animation if available)
            if (doorAnimator != null)
            {
                doorAnimator.SetBool("IsOpen", true);  // Trigger door animation if it has an "IsOpen" parameter
            }
            else if (door != null)
            {
                door.SetActive(true);  // Alternative door open logic if no animator
            }
        }
        else
        {
            // Play incorrect audio
            if (incorrectAudio != null)
                incorrectAudio.Play();

            // Display "False" in the resultText
            if (resultText != null)
                resultText.text = "False";
        }
    }
}