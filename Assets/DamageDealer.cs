using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damageAmount = 15f; // Damage dealt by the bear's attack

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[BearDamageDealer] Triggered with: {other.name}"); // Log the object hit

        if (other.CompareTag("Player")) // Check if the object has the "Player" tag
        {
            Debug.Log("[BearDamageDealer] Player detected!");

            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount); // Apply damage to the player
                Debug.Log($"[BearDamageDealer] Dealt {damageAmount} damage to {other.name}");
            }
            else
            {
                Debug.LogWarning("[BearDamageDealer] PlayerHealth component not found on the player!");
            }
        }
    }
}
