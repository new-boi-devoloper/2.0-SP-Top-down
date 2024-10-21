using UnityEngine;
using UnityEngine.AI;
using Vector2 = UnityEngine.Vector2;

namespace EnemyScripts.EnemyMovement
{
    public class WanderEnemyMoveStrategy : IEnemyMovementStrategy
    {
        private readonly Vector2 wanderCenter;
        private readonly float wanderRadius;

        public WanderEnemyMoveStrategy(Vector2 center, float radius)
        {
            wanderCenter = center;
            wanderRadius = radius;
        }

        public void Move(Transform transform, NavMeshAgent agent)
        {
            if (!agent.hasPath || agent.remainingDistance < 0.5f)
            {
                var randomDirection = Random.insideUnitCircle * wanderRadius;
                var targetPosition = wanderCenter + randomDirection;
                agent.SetDestination(targetPosition);
            }
        }
    }
}