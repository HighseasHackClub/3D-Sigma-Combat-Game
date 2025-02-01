using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;          // Reference to the player’s transform
    public float speed = 2f;          // Enemy movement speed
    public float attackRange = 1.5f;  // Distance to trigger an attack

    void Update()
    {
        // Move towards the player if within range
        if (Vector3.Distance(transform.position, player.position) > attackRange)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {
        // Logic for damaging the player
        Debug.Log("Enemy attacks!");
    }
}
