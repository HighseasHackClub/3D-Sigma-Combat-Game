using UnityEngine;

public class PunchVFXController : MonoBehaviour
{
    [Header("VFX Settings")]
    public GameObject punchVFXPrefab;     // Assign the VFX prefab in the Inspector
    public Transform leftHandSpawnPoint; // Left hand spawn point
    public Transform rightHandSpawnPoint; // Right hand spawn point

    public void TriggerPunchVFX(string activeArm)
    {
        Transform currentSpawnPoint = null;

        // Determine the active arm and set the current spawn point
        if (activeArm == "Left")
        {
            currentSpawnPoint = leftHandSpawnPoint;
        }
        else if (activeArm == "Right")
        {
            currentSpawnPoint = rightHandSpawnPoint;
        }

        // Instantiate the VFX at the spawn point
        if (currentSpawnPoint != null && punchVFXPrefab != null)
        {
            GameObject vfx = Instantiate(punchVFXPrefab, currentSpawnPoint.position, currentSpawnPoint.rotation);
            Destroy(vfx, .5f); // Destroy the VFX after 2 seconds
        }
        else
        {
            Debug.LogWarning("Punch VFX prefab or spawn point is missing!");
        }
    }
}
