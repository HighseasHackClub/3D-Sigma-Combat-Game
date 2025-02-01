using GinjaGaming.FinalCharacterController;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public string playerTag = "Player"; // Tag assigned to the player GameObject

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                // Notify the player that the wand has been collected
                playerController.CollectWand();

                // Destroy the pickup object
                Destroy(gameObject);

                Debug.Log("Wand picked up!");
            }
        }
    }
}
