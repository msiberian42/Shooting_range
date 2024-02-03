namespace ShootingRange.Features.Enemies
{
    using UnityEngine;
    using UnityEngine.AI;

    /// <summary>
    /// Контроллер врага
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyController : MonoBehaviour
    {
        protected NavMeshAgent agent = default;
        protected EnemyTargetsController targetsController = default;
        protected Transform target = default;
        protected EnemyPoolManager poolManager = default;

        protected virtual void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            targetsController = FindAnyObjectByType<EnemyTargetsController>();
            poolManager = FindAnyObjectByType<EnemyPoolManager>();
        }

        protected virtual void OnEnable()
        {
            if (targetsController != null)
            {
                target = targetsController.GetRandomTarget();
                agent.SetDestination(target.position);
            }
        }

        public virtual void OnTargetReached()
        {
            target = null;
            poolManager.ReleaseEnemy(this);
        }
    }
}