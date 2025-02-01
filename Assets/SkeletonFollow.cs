using UnityEngine;
using UnityEngine.AI;

public class SkeletonFollow : MonoBehaviour
{
    public Transform player; // Assign the player in the Inspector or find it dynamically
    public float detectionRadius = 18f; // Radius within which the bear will start following
    public float attackRadius = 1.5f; // Radius within which the bear will stop and attack

    private NavMeshAgent agent;

    void Start()
    {
        // Get the NavMeshAgent component on the bear
        agent = GetComponent<NavMeshAgent>();

        // If player is not assigned in the Inspector, find it by tag
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }

        // Check if NavMeshAgent is properly set up
        if (agent == null)
        {

            return;
        }

        if (!agent.isOnNavMesh)
        {

        }
    }

    void Update()
    {
        // If player or agent is null, do nothing
        if (player == null || agent == null) return;

        // Calculate distance to player
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        // Check if the player is within detection radius
        if (distanceToPlayer < detectionRadius && distanceToPlayer > (attackRadius + 0.1f))
        {
            // Move towards the player
            agent.isStopped = false;
            agent.SetDestination(player.position);

        }
        else if (distanceToPlayer <= attackRadius)
        {
            // Stop moving when within attack radius
            agent.isStopped = true;

            // Optionally, trigger an attack or other behavior here

        }
        else
        {
            // Player is out of range, stop the bear from moving
            agent.isStopped = true;
        }
    }
}