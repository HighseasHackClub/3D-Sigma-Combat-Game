using UnityEngine;

public class PlayerDamageDealer : MonoBehaviour
{
    public float damageAmount = 10f; // Damage dealt by the player’s attack

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[PlayerDamageDealer] Triggered with: {other.name}"); // Log the object hit

        if (other.CompareTag("Enemy")) // Check if the object has the "Enemy" tag
        {
            Debug.Log("[PlayerDamageDealer] Enemy detected!");

            // Handle Bear
            BearHealth bearHealth = other.GetComponent<BearHealth>();
            if (bearHealth != null)
            {
                bearHealth.TakeDamage(damageAmount); // Apply damage
                Debug.Log($"[PlayerDamageDealer] Dealt {damageAmount} damage to {other.name}");
            }

            // Handle Skeleton
            SkeletonHealth skeletonHealth = other.GetComponent<SkeletonHealth>();
            if (skeletonHealth != null)
            {
                skeletonHealth.TakeDamage(damageAmount); // Apply damage
                Debug.Log($"[PlayerDamageDealer] Dealt {damageAmount} damage to {other.name}");
            }
        }
    }

    // Method to increase damage
    public void DamageIncrease1(float damageIncrease)
    {
        damageAmount += damageIncrease;
        Debug.Log($"[PlayerDamageDealer] Damage increased to {damageAmount}!");
    }
}
