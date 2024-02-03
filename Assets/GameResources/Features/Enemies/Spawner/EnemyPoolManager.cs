namespace ShootingRange.Features.Enemies
{
    using UnityEngine;
    using UnityEngine.Pool;

    /// <summary>
    /// Менеджер пула врагов
    /// </summary>
    public class EnemyPoolManager : MonoBehaviour
    {
        [SerializeField]
        protected EnemyController enemyPrefab = default;

        [SerializeField]
        protected Transform enemiesParent = default;

        protected ObjectPool<EnemyController> enemyPool = default;

        protected virtual void Awake()
        {
            enemyPool = new ObjectPool<EnemyController>(
                createFunc: () => Instantiate(enemyPrefab, enemiesParent),
                actionOnGet: (obj) => obj.gameObject.SetActive(true),
                actionOnRelease: (obj) => obj.gameObject.SetActive(false),
                actionOnDestroy: (obj) => Destroy(obj.gameObject),
                collectionCheck: true,
                defaultCapacity: 10,
                maxSize: 100);
        }

        /// <summary>
        /// Возвращает врага из пула
        /// </summary>
        public virtual EnemyController GetEnemy() => enemyPool.Get();

        /// <summary>
        /// Возвращает врага в пул
        /// </summary>
        public virtual void ReleaseEnemy(EnemyController enemy) => enemyPool.Release(enemy);
    }
}