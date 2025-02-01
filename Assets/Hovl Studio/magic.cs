using UnityEngine;
using System.Collections; // Required to use Coroutines

public class CharacterAttackWithVFX : MonoBehaviour
{
    // Reference to the magic effect prefab (drag the VFX prefab from your assets here in the Inspector)
    public GameObject magicEffectPrefab;

    // Reference to the transform from which the magic effect will spawn (e.g., the hand or weapon)
    public Transform spawnPoint;

    // Cooldown time between attacks (optional, adjust as needed)
    public float attackCooldown = 1f;
    private float nextAttackTime = 0f;

    // Delay before the magic effect plays (in seconds)
    public float effectDelay = 0.5f;

    void Update()
    {
        // Check for left mouse button click (0 is the left mouse button) and cooldown timing
        if (Input.GetMouseButtonDown(0) && Time.time >= nextAttackTime)
        {
            // Start the magic effect with a delay
            StartCoroutine(CastMagicWithDelay());

            // Set the time for the next attack (for cooldown)
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    IEnumerator CastMagicWithDelay()
    {
        // Wait for the delay time before casting the magic effect
        yield return new WaitForSeconds(effectDelay);

        // Instantiate the magic effect prefab at the specified spawn point position and rotation
        GameObject magicEffect = Instantiate(magicEffectPrefab, spawnPoint.position, spawnPoint.rotation);

        // Optionally, destroy the magic effect after a duration to clean up the scene
        Destroy(magicEffect, .6f); // Adjust the duration based on your VFX length
    }
}
