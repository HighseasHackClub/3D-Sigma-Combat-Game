using UnityEngine;

public class VFXController : MonoBehaviour
{
    // Drag the Stone Slash prefab here from the Inspector
    public GameObject stoneSlashVFX;

    // You can set an offset from the player (optional)
    public Vector3 offset = new Vector3(0, 1, 0);

    // Lifetime of the VFX before it disappears
    public float vfxLifetime = .3f;  // Adjust the lifetime as needed

    void Update()
    {
        // Check if the left mouse button (button 0) is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position and convert it to a point in the world
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            // Check if the ray hits anything in the world
            if (Physics.Raycast(ray, out hit))
            {
                // Instantiate the Stone Slash VFX at the hit point
                GameObject vfxInstance = Instantiate(stoneSlashVFX, hit.point + offset, Quaternion.identity);

                // Destroy the VFX after the specified lifetime
                Destroy(vfxInstance, vfxLifetime);
            }
            else
            {
                // If there's no hit, instantiate the VFX in front of the player or at a default position
                Vector3 spawnPosition = transform.position + transform.forward + offset;
                GameObject vfxInstance = Instantiate(stoneSlashVFX, spawnPosition, Quaternion.identity);

                // Destroy the VFX after the specified lifetime
                Destroy(vfxInstance, vfxLifetime);
            }
        }
    }
}
