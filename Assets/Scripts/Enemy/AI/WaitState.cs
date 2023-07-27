using System.Collections;
using UnityEngine;

public class WaitState : AIStateMachine
{
    [Header("Wait")]
    [SerializeField] private float minWaitDelay;
    [SerializeField] private float maxWaitDelay;
    private Coroutine waitCoroutine;

    public override void EnterState()
    {
        if (waitCoroutine != null)
        {
            StopCoroutine(waitCoroutine);
        }

        waitCoroutine = StartCoroutine(Wait());

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(Random.Range(minWaitDelay, maxWaitDelay + 1f));
            enemyAI.SetState(AIStateEnum.Patrol);
        }
    }

    public override void ExitState()
    {
        if (waitCoroutine != null)
        {
            StopCoroutine(waitCoroutine);
        }
    }

    public override void UpdateState()
    {
        // Found player while waiting
        // Switch to chase state
    }
}