using UnityEngine;

public class CursorController : MonoBehaviour
{
    void Start()
    {
        // Initially lock and hide the cursor when the game starts
        LockCursor();
    }

    void Update()
    {
        // If the player clicks (left-click or touch), lock the cursor and hide it
        if (Input.GetMouseButtonDown(0)) // Left-click or tap
        {
            LockCursor();
        }
    }

    void LockCursor()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Optional: Add a method to unlock the cursor (e.g., when you pause the game)
    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
