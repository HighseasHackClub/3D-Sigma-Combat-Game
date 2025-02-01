using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider; // Reference to the UI Slider

    // Set the maximum health in the slider
    public void SetMaxHealth(float maxHealth)
    {
        healthSlider.maxValue = maxHealth;  // Set the slider's max value
    }

    // Update the slider to reflect the current health
    public void SetHealth(float health)
    {
        healthSlider.value = health;
    }
}

