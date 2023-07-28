using System.Collections;
using Cinemachine;
using UnityEngine;

public class AttackState : AIStateMachine
{
    [Header("Attack")]
    [SerializeField] private CinemachineVirtualCamera catchPlayerCamera;

    public override void EnterState()
    {
        StartCoroutine(CatchPlayer());

        IEnumerator CatchPlayer()
        {
            catchPlayerCamera.enabled = true;
            enemyAI.player.GetComponent<ThirdPersonController>().EnableController(false, true);
            enemyAI.Animator.SetTrigger("Attack");
            yield return new WaitForSeconds(2.5f);
            enemyAI.SetState(AIStateEnum.Wait);
            yield return new WaitForSeconds(1f);
            catchPlayerCamera.enabled = false;
        }
    }

    public override void ExitState()
    {
    }

    public override void UpdateState()
    {
    }
}