using UnityEngine;

public class PunchController : MonoBehaviour
{
    public float punchCooldown = 1f;         // Cooldown time between punches
    private float lastPunchTime = -1f;       // Track the time of the last punch
    private bool isTimePassed = false;       // Tracks if 1 second has passed after a punch

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Update punchTimer parameter based on time since last punch
        animator.SetFloat("punchTimer", Time.time - lastPunchTime);

        // Detect left mouse click and check cooldown
        if (Input.GetMouseButtonDown(0) && Time.time >= lastPunchTime + punchCooldown)
        {
            // Toggle isLeftPunch to alternate between punches
            bool isLeftPunchNext = !animator.GetBool("isLeftPunch");
            animator.SetBool("isLeftPunch", isLeftPunchNext);

            // Update last punch time
            lastPunchTime = Time.time;

            // Reset the isTimePassed flag
            isTimePassed = false;
        }

        // Check if 1 second has passed since the last punch
        if (!isTimePassed && Time.time >= lastPunchTime + 1f)
        {
            // Set the isTimePassed flag
            isTimePassed = true;

            // Trigger the exit condition
        }
    }
}
