using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyScripts.EnemyMovement
{
    public class PatrolEnemyMoveStrategy : IEnemyMovementStrategy
    {
        private List<GameObject> patrolPoints;
        private int currentPointIndex;
        private bool movingForward = true;

        public PatrolEnemyMoveStrategy(List<GameObject> points)
        {
            patrolPoints = points;
        }

        public void Move(Transform transform, NavMeshAgent agent)
        {
            if (!agent.hasPath || agent.remainingDistance < 0.5f)
            {
                agent.SetDestination(patrolPoints[currentPointIndex].transform.position);
                UpdatePointIndex();
            }
        }

        private void UpdatePointIndex()
        {
            if (movingForward)
            {
                currentPointIndex++;
                if (currentPointIndex >= patrolPoints.Count)
                {
                    currentPointIndex = patrolPoints.Count - 2;
                    movingForward = false;
                }
            }
            else
            {
                currentPointIndex--;
                if (currentPointIndex < 0)
                {
                    currentPointIndex = 1;
                    movingForward = true;
                }
            }
        }

    }
}