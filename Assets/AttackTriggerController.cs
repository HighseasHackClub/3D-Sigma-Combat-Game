using UnityEngine;

public class AttackTriggerController : MonoBehaviour
{
    public Collider attackCollider;  // Reference to the first attack collider
    public Collider attackCollider2; // Reference to the second attack collider

    private bool isUsingFirstCollider = true; // Tracks which collider is currently active

    // Toggles between the two colliders
    public void ToggleAttackColliders()
    {
        if (isUsingFirstCollider)
        {
            EnableCollider1();
        }
        else
        {
            EnableCollider2();
        }
        isUsingFirstCollider = !isUsingFirstCollider; // Switch the active collider
    }

    // Enable the first attack collider and disable the second
    public void EnableCollider1()
    {
        if (attackCollider != null)
        {
            attackCollider.enabled = true;
            Debug.Log("[AttackTriggerController] Attack Collider 1 enabled.");
        }

        if (attackCollider2 != null)
        {
            attackCollider2.enabled = false;
            Debug.Log("[AttackTriggerController] Attack Collider 2 disabled.");
        }
    }

    // Enable the second attack collider and disable the first
    public void EnableCollider2()
    {
        if (attackCollider2 != null)
        {
            attackCollider2.enabled = true;
            Debug.Log("[AttackTriggerController] Attack Collider 2 enabled.");
        }

        if (attackCollider != null)
        {
            attackCollider.enabled = false;
            Debug.Log("[AttackTriggerController] Attack Collider 1 disabled.");
        }
    }

    // Disable both colliders
    public void DisableAllColliders()
    {
        if (attackCollider != null)
        {
            attackCollider.enabled = false;
            Debug.Log("[AttackTriggerController] Attack Collider 1 disabled.");
        }

        if (attackCollider2 != null)
        {
            attackCollider2.enabled = false;
            Debug.Log("[AttackTriggerController] Attack Collider 2 disabled.");
        }
    }
}
