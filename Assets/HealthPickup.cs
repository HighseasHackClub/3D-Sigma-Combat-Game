using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float healthRestoreAmount = 40f; // Amount of health restored when picked up
    public string playerTag = "Player";    // The tag assigned to your player GameObject    

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag(playerTag))
        {
            // Get the player's Health script
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                // Restore health
                playerHealth.RestoreHealth(healthRestoreAmount);

                // Optionally, play a sound or particle effect here

                // Destroy the health pickup
                Destroy(gameObject);
            }
        }
    }
}
