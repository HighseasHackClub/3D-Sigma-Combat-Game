using UnityEngine;
using UnityEngine.AI;

public class BearHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;   // Maximum health
    private float currentHealth;     // Current health value
    private bool isDead = false;     // Tracks if the bear is dead

    [Header("References")]
    public HealthBar healthBar;      // Reference to the health bar
    public GameObject swordPrefab;   // Sword prefab to drop
    private Animator animator;       // Reference to the Animator component
    public GameObject SkellyBoss;    // Special entity prefab (Skeleton Boss)
    public GameObject PowerUp1;      // Power-up prefab

    private static int bearKillCounter = 0; // Static counter to track kills globally

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
        if (isDead) return;

        isDead = true; // Mark the bear as dead
        Debug.Log("[BearHealth] isDead set to true.");

        // Trigger death animation
        if (animator != null)
        {
            animator.SetBool("isDead", true);
            Debug.Log("[BearHealth] Death animation triggered.");
        }
        else
        {
            Debug.LogWarning("[BearHealth] Animator is missing. Animation not triggered.");
        }

        // Notify the Quest System
        QuestSystem questSystem = FindObjectOfType<QuestSystem>();
        if (questSystem != null)
        {
            questSystem.RegisterKill();
            Debug.Log("[BearHealth] Quest system notified.");
        }

        // Increment the kill counter
        bearKillCounter++;
        Debug.Log($"[BearHealth] Kill counter: {bearKillCounter}");
        if (bearKillCounter > 0 && bearKillCounter % 10 == 0)
        {
            SpawnSpecialEntity();
        }

        // Drop items
        DropSword();

        // Disable AI and collider
        if (GetComponent<NavMeshAgent>() != null) GetComponent<NavMeshAgent>().enabled = false;
        if (GetComponent<BearFollower>() != null) GetComponent<BearFollower>().enabled = false;
        if (GetComponent<Collider>() != null) GetComponent<Collider>().enabled = false;

        // Destroy the object after animation
        Destroy(gameObject, 6f);
    }

    private void SpawnSpecialEntity()
    {
        if (SkellyBoss != null)
        {
            Vector3 spawnPosition = transform.position + Vector3.up * 1f; // Spawn at the bear's position
            Instantiate(SkellyBoss, spawnPosition, Quaternion.identity);
            Debug.Log("[BearHealth] Special entity (SkellyBoss) spawned!");
        }
        else
        {
            Debug.LogWarning("[BearHealth] SkellyBoss prefab is not assigned!");
        }
    }

    private void DropSword()
    {
        if (swordPrefab != null)
        {
            // Add an offset to the position to spawn the sword higher
            Vector3 spawnPosition = transform.position + Vector3.up * 1f; // Adjust for desired height
            Vector3 powerUpPosition = transform.position + Vector3.right * 1.5f + Vector3.up * 1f;
            Instantiate(swordPrefab, spawnPosition, Quaternion.identity);
            Instantiate(PowerUp1, powerUpPosition, Quaternion.identity);
            Debug.Log("[BearHealth] Sword and power-up dropped!");
        }
        else
        {
            Debug.LogWarning("[BearHealth] Sword prefab is not assigned!");
        }
    }
}
