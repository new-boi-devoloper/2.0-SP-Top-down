using System.Collections.Generic;
using _Source.Scripts.EnemyScripts.EnemyInterfaces;
using _Source.Scripts.EnemyScripts.EnemyStates;
using EnemyScripts.EnemyManagement;
using UnityEngine;

namespace EnemyScripts.Enemies
{
    public class RaiderEnemy : EnemyBase, IDiie
    {
        [SerializeField] private List<GameObject> patrolPoints;
        private DeathState _deathState;

        protected override void InitializeStrategies()
        {
            if (isMoving)
            {
                MovementSystem = new EnemyMovementSystem(gameObject, moveType, patrolPoints);
            }

            if (isAttacking)
            {
                AttackSystem = new EnemyAttackSystem(gameObject, attackType);
            }
        }

        protected override void InitializeStates()
        {
            _deathState = new DeathState();
        }


        public void Die()
        {
            StateMachine.ChangeState(_deathState, this);
            StateMachine.Execute(this);
        }
    }
}