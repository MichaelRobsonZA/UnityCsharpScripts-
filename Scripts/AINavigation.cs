using UnityEngine;
using UnityEngine.AI;

public class AINavigation : MonoBehaviour
{
    // The NavMeshAgent component attached to the enemy game object
    private NavMeshAgent agent;

    // The target transform that the enemy will chase
    public Transform target;

    void Start()
    {
        // Get the NavMeshAgent component attached to the enemy game object
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Set the destination of the NavMeshAgent to the target's position
        agent.destination = target.position;
    }
}
