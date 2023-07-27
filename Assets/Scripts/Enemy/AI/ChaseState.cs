using UnityEngine;

public class ChaseState : AIStateMachine
{
    [Header("Chase")]
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float chaseDistance;

    public override void EnterState()
    {
        enemyAI.Agent.isStopped = false;
        enemyAI.Agent.speed = chaseSpeed;
    }

    public override void ExitState()
    {
    }

    public override void UpdateState()
    {
        if (enemyAI.player != null)
        {
            // Chasing player
            enemyAI.Agent.SetDestination(enemyAI.player.transform.position);

            // Player is in the chasing area
            if (enemyAI.Agent.remainingDistance < chaseDistance)
            {
                // Reached the distance to attack the player
                if (enemyAI.Agent.remainingDistance <= enemyAI.Agent.stoppingDistance)
                {
                    enemyAI.SetState(AIStateEnum.Attack);
                }
            }
            // Player is out of the chasing area
            else
            {
                // Find player again
                enemyAI.player = enemyAI.FindPlayer();

                // Lost the player, back to waiting state (after finished waiting it will switch to patrol state)
                if (enemyAI.player == null)
                {
                    enemyAI.SetState(AIStateEnum.Wait);

                    // Find closet waypoint for patrol state
                    if (enemyAI.stateMachines[1] is PatrolState)
                    {
                        PatrolState patrolStateInstance = (PatrolState)enemyAI.stateMachines[1];
                        patrolStateInstance.FindClosetWaypoint();
                    }
                    else
                    {
                        Debug.LogError("State Machine index[1] is not Patrol state");
                    }
                }
                // In the first time player is out of the chasing area but player is come back into the chasing area again -*-
                else
                {
                    enemyAI.SetState(AIStateEnum.Chase);
                }
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
    }
#endif
}