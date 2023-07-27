using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private EnemyController m_enemyController;
    private NavMeshAgent m_agent;
    public NavMeshAgent Agent => m_agent;

    [Header("AI State")]
    [SerializeField] private AIStateMachine currentState;

    [Header("States")]
    [SerializeField] private AIStateMachine[] stateMachines;

    private void Start()
    {
        m_enemyController = GetComponent<EnemyController>();
        m_agent = GetComponent<NavMeshAgent>();

        // Start the state by waiting
        SetState(AIStateEnum.Wait);

        // Find closet waypoint for patrol state
        if (stateMachines[1] is PatrolState)
        {
            PatrolState patrolStateInstance = (PatrolState)stateMachines[1];
            patrolStateInstance.FindClosetWaypoint();
        }
    }

    private void Update()
    {
        UpdateState();
    }

    public void SetState(AIStateEnum newIAState)
    {
        if (currentState != null)
        {
            // Reset state and exit
            currentState.ExitState();
        }

        // Set new state
        switch (newIAState)
        {
            case AIStateEnum.Wait:
                currentState = stateMachines[0];
                break;
            case AIStateEnum.Patrol:
                currentState = stateMachines[1];
                break;
            case AIStateEnum.Chase:
                currentState = stateMachines[2];
                break;
            case AIStateEnum.Attack:
                currentState = stateMachines[3];
                break;
        }

        // Init state 
        currentState.EnterState();
    }

    private void UpdateState()
    {
        if (m_agent.enabled)
        {
            if (currentState != null)
            {
                currentState.UpdateState();
            }
        }
    }
}

public enum AIStateEnum
{
    Wait,
    Patrol,
    Chase,
    Attack,
}