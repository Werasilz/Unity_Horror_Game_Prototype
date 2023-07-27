using UnityEngine;

public class PatrolState : AIStateMachine
{
    [Header("Patrol")]
    [SerializeField] private float patrolSpeed;
    [SerializeField] private int currentWaypointIndex;
    [SerializeField] private Transform[] waypoints;

    public override void EnterState()
    {
        // Set destination to waypoint
        enemyAI.Agent.isStopped = false;
        enemyAI.Agent.speed = patrolSpeed;
        enemyAI.Agent.SetDestination(waypoints[currentWaypointIndex].position);
    }

    // Call when first time spawn or after chasing the player
    public void FindClosetWaypoint()
    {
        // Find the closest waypoint
        float closestDistance = Mathf.Infinity;
        int closestWaypointIndex = 0;

        for (int i = 0; i < waypoints.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, waypoints[i].position);

            // Found new closet waypoint
            if (distance < closestDistance)
            {
                // Update to closet waypoint
                closestDistance = distance;
                closestWaypointIndex = i;
            }
        }

        // Update the final closet waypoint to current waypoint
        currentWaypointIndex = closestWaypointIndex;
    }

    public override void ExitState()
    {
    }

    public override void UpdateState()
    {
        // Found player while patrolling
        enemyAI.player = enemyAI.FindPlayer();

        if (enemyAI.player != null)
        {
            enemyAI.SetState(AIStateEnum.Chase);
            return;
        }

        // Reached the waypoint then go to the next waypoint
        if (enemyAI.Agent.remainingDistance <= enemyAI.Agent.stoppingDistance)
        {
            // Set next waypoint
            currentWaypointIndex += 1;
            if (currentWaypointIndex > waypoints.Length - 1) currentWaypointIndex = 0;

            // Switch to wait state
            enemyAI.SetState(AIStateEnum.Wait);
        }
    }
}