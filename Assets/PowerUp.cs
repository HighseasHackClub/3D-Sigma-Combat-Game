using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float damageIncrease = 5f; // Amount of damage to increase
    public string playerTag = "Player"; // Tag assigned to the player GameObject

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag(playerTag))
        {
            // Find the PlayerDamageDealer script on the player's arms
            PlayerDamageDealer[] damageDealers = other.GetComponentsInChildren<PlayerDamageDealer>();
            if (damageDealers.Length > 0)
            {
                foreach (PlayerDamageDealer damageDealer in damageDealers)
                {
                    // Increase the damage for all arms
                    damageDealer.DamageIncrease1(damageIncrease);
                }
                Debug.Log($"[PowerUp] Increased player's damage by {damageIncrease}!");
            }
            else
            {
                Debug.LogWarning("[PowerUp] No PlayerDamageDealer components found on the player's arms!");
            }

            // Optionally, play a sound or particle effect here

            // Destroy the power-up after being used
            Destroy(gameObject);
        }
    }
}
