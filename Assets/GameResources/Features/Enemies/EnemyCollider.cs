namespace ShootingRange.Features.Enemies
{
    using UnityEngine;

    /// <summary>
    /// Коллайдер врага
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class EnemyCollider : MonoBehaviour
    {
        [SerializeField]
        protected EnemyController controller = default;

        /// <summary>
        /// Враг дошел до цели
        /// </summary>
        public virtual void OnTargetReached() => controller?.OnTargetReached();
    }
}
