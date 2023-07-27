using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyAI m_enemyAI;
    private Animator m_animator;

    private float m_moveSpeed = 1f;
    private float m_speedChangeRate = 10f;

    private float m_animationBlend;
    private int m_animIDSpeed;

    void Start()
    {
        m_enemyAI = GetComponent<EnemyAI>();
        m_animator = GetComponent<Animator>();

        m_animIDSpeed = Animator.StringToHash("Speed");
    }

    void Update()
    {
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        // Set speed
        bool isMoving = m_enemyAI.Agent.velocity.magnitude > 0.1f;
        float targetSpeed = isMoving ? m_moveSpeed : 0.0f;

        // Update animation blend
        m_animationBlend = Mathf.Lerp(m_animationBlend, targetSpeed, Time.deltaTime * m_speedChangeRate);
        if (m_animationBlend < 0.01f) m_animationBlend = 0f;
        m_animator.SetFloat(m_animIDSpeed, m_animationBlend);
    }
}
