using System.Collections.Generic;
using EnemyScripts.EnemyMovement;
using UnityEngine;

namespace EnemyScripts.EnemyManagement
{
    public class EnemyMovementSystem
    {
        public IEnemyMovementStrategy MovementStrategy { get; private set; }
        private MoveType _moveType;

        public EnemyMovementSystem(GameObject gameObject, MoveType currentMoveType, List<GameObject> patrolPoints)
        {
            _moveType = currentMoveType;
            switch (currentMoveType)
            {
                case MoveType.Patrol:
                    MovementStrategy = new PatrolEnemyMoveStrategy(patrolPoints);
                    break;
                case MoveType.Flee:
                    MovementStrategy = new FleeEnemyMoveStrategy(Vector2.zero, 10f);
                    break;
                case MoveType.Wander:
                    MovementStrategy = new WanderEnemyMoveStrategy(Vector2.zero, 10f);
                    break;
                case MoveType.Still:
                    MovementStrategy = new StillEnemyMoveStrategy();
                    break;
                default:
                    throw new System.ArgumentOutOfRangeException($"not choosen enemy move type in {gameObject}");
            }
        }
    }
}

public enum MoveType
{
    Patrol,
    Flee,
    Wander,
    Still
}