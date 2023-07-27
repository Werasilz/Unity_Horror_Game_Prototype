using UnityEngine;

public abstract class AIStateMachine : MonoBehaviour
{
    public EnemyAI enemyAI;
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
}