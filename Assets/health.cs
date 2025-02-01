using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f; // Maximum health
    private float currentHealth;  // Current health
    public bool isDead = false;

    public HealthBar healthBar;   // Reference to the health bar
    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); // Initialize health bar
        healthBar.SetHealth(currentHealth);
        animator = GetComponent<Animator>();// Set the initial value
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health stays in bounds

        Debug.Log($"[PlayerHealth] Took {damage} damage! Current health: {currentHealth}"); // Log health change

        healthBar.SetHealth(currentHealth); // Update the health bar

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void RestoreHealth(float healthAmount)
    {
        currentHealth += healthAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Prevent overhealing
        healthBar.SetHealth(currentHealth);
    }
    private void Die()
    {
        isDead = true; // Mark the bear as dead
        Debug.Log("[BearHealth] Bear has died!");

        // Trigger death animation
        animator.SetBool("isDead", true);

        // Drop the sword at the bear's position

        // Disable other components to stop behavior
        GetComponent<BearFollower>().enabled = false; // Disable AI script (replace with your AI script name)
        GetComponent<Collider>().enabled = false; // Prevent further collisions

        // Destroy the bear after the death animation plays
        Destroy(gameObject, 6f); // Adjust the delay to match your animation length
    }
}
