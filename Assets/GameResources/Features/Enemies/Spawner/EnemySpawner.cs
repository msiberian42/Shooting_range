namespace ShootingRange.Features.Enemies
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    /// <summary>
    /// Спавнер врагов
    /// </summary>
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        protected List<Transform> spawnPoints = new List<Transform>();

        [SerializeField]
        protected float cooldown = 1f;

        [SerializeField]
        protected EnemyPoolManager poolManager = default;

        protected bool spawnAllowed = true;

        protected Coroutine spawnRoutine = default;

        protected EnemyController enemy = default;

        protected virtual void Start() => 
            spawnRoutine = StartCoroutine(SpawnEnemiesRoutine());

        protected virtual IEnumerator SpawnEnemiesRoutine()
        {
            while (isActiveAndEnabled && spawnAllowed)
            {
                yield return new WaitForSecondsRealtime(cooldown);

                enemy = poolManager?.GetEnemy();
                enemy.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
            }
        }
    }
}