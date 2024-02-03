namespace ShootingRange.Features.Enemies
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Контроллер целей для врагов
    /// </summary>
    public class EnemyTargetsController : MonoBehaviour
    {
        [SerializeField]
        protected List<Transform> targets = new List<Transform>();

        /// <summary>
        /// Возвращает случайную цель
        /// </summary>
        public virtual Transform GetRandomTarget() => 
            targets[Random.Range(0, targets.Count)];
    }
}