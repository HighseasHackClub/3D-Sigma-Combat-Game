using UnityEngine;
using UnityEngine.AI;

public class BearTest: MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }
        else
        {
            Debug.LogError("Player Transform is missing!");
        }
    }
}
