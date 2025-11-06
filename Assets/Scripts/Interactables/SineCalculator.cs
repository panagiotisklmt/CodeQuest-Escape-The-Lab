using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SineCalculatorWithDropdowns : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown1;
    [SerializeField] private TMP_Dropdown dropdown2;
    [SerializeField] private TMP_Dropdown dropdown3;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Button validateButton;

    private void Awake()  // Use Awake to ensure the listener is added early
    {
        if (validateButton != null)
        {
            validateButton.onClick.AddListener(CalculateSine);
        }
        else
        {
            Debug.LogError("Validate button is not assigned in the Inspector.");
        }
    }

    private void CalculateSine()
    {
        Debug.Log("CalculateSine method triggered");

        // Get the selected values
        int digit1 = dropdown1.value;
        int digit2 = dropdown2.value;
        int digit3 = dropdown3.value;

        // Calculate the angle
        int angle = digit1 * 100 + digit2 * 10 + digit3;

        if (angle < 0 || angle > 360)
        {
            resultText.text = "Invalid angle";
            Debug.LogWarning("Angle out of range: " + angle);
            return;
        }

        // Calculate sine
        float radians = angle * Mathf.Deg2Rad;
        float sineValue = Mathf.Sin(radians);

        // Display result
        resultText.text = sineValue.ToString("F6");
        Debug.Log("Calculated sine value: " + sineValue);
    }
}