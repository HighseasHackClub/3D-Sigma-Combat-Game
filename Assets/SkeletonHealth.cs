using UnityEngine;
using UnityEngine.AI;

public class SkeletonHealth : MonoBehaviour
{
    private const bool V = false;
    [Header("Health Settings")]
    public float maxHealth = 150f;   // Maximum health
    private float currentHealth;     // Current health value
    private bool isDead = false;     // Tracks if the bear is dead

    [Header("References")]
    public HealthBar healthBar;      // Reference to the health bar
    private Animator animator;       // Reference to the Animator component
    public GameObject swordPrefab;
    void Start()
    {
        // Initialize health and components
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); // Set the max value for the health bar
        healthBar.SetHealth(currentHealth); // Set the initial health value
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return; // Ignore damage if the bear is already dead

        // Reduce health and update the health bar
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Clamp health to avoid negative values
        healthBar.SetHealth(currentHealth);

        Debug.Log($"[BearHealth] Took {damage} damage! Current health: {currentHealth}");

        // Check if the bear should die
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true; // Mark the bear as dead


        // Trigger death animation
        animator.SetBool("isDead", true);

        // Drop the sword at the bear's position

        // Disable other components to stop behavior
        GetComponent<NavMeshAgent>().enabled = V; // Stop navigation (if using NavMeshAgent)
        GetComponent<SkeletonFollow>().enabled = false; // Disable AI script (replace with your AI script name)
        GetComponent<Collider>().enabled = false; // Prevent further collisions

        // Destroy the bear after the death animation plays
        Destroy(gameObject, 6f); // Adjust the delay to match your animation length
        Vector3 spawnPosition = transform.position + Vector3.up * 1f;
        Instantiate(swordPrefab, spawnPosition, Quaternion.identity);
    }

 
}
