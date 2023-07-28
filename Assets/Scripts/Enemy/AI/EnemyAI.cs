using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private EnemyController m_enemyController;
    public NavMeshAgent Agent { get; private set; }
    public Animator Animator { get; private set; }

    [Header("AI State")]
    [SerializeField] private AIStateMachine currentState;

    [Header("States")]
    public AIStateMachine[] stateMachines;

    [Header("Target")]
    public PlayerCore player;

    [Header("Scan Settings")]
    [SerializeField] private float scanRadius;
    [SerializeField] private LayerMask playerLayer;

    private void Start()
    {
        m_enemyController = GetComponent<EnemyController>();
        Agent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();

        // Start the state by waiting
        SetState(AIStateEnum.Wait);
        PatrolFindClosetWaypoint();
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
        if (Agent.enabled)
        {
            if (currentState != null)
            {
                currentState.UpdateState();
            }
        }
    }

    public PlayerCore FindPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, scanRadius, playerLayer);

        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                return colliders[i].GetComponent<PlayerCore>();
            }
        }

        return null;
    }

    public void PatrolFindClosetWaypoint()
    {
        // Find closet waypoint for patrol state
        if (stateMachines[1] is PatrolState)
        {
            PatrolState patrolStateInstance = (PatrolState)stateMachines[1];
            patrolStateInstance.FindClosetWaypoint();
        }
        else
        {
            Debug.LogError("State Machine index[1] is not Patrol state");
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, scanRadius);
    }
#endif
}

public enum AIStateEnum
{
    Wait,
    Patrol,
    Chase,
    Attack,
}