namespace ShootingRange.Features.Enemies
{
    using UnityEngine;

    /// <summary>
    /// Коллайдер цели
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class TargetCollider : MonoBehaviour
    {
        protected Collider2D coll = default;

        protected virtual void Awake()
        {
            coll = GetComponent<Collider2D>();
            coll.isTrigger = true;
        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            EnemyCollider enemy = collision.gameObject.GetComponent<EnemyCollider>();

            if (enemy != null)
            {
                enemy.OnTargetReached();
            }
        }
    }
}