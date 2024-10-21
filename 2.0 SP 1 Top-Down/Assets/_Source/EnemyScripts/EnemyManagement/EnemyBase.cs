using System.Collections.Generic;
using EnemyScripts.EnemyAttack;
using EnemyScripts.EnemyMovement;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace EnemyScripts.EnemyManagement
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Health))]
    public abstract class EnemyBase : MonoBehaviour
    {
        [field: Header("Enemy Setup")]
        public CharacterType EnemyCharacter;
        public bool isMoving;
        public bool isAttacking;
        public bool isAlerting;

        [SerializeField] internal MoveType moveType;
        [SerializeField] internal AttackType attackType;

        internal EnemyMovementSystem MovementSystem { get; set; }
        internal EnemyAttackSystem AttackSystem { get; set; }
        internal StateMachine StateMachine { get; set; }
        
        private NavMeshAgent agent;

        
        protected virtual void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            StateMachine = new StateMachine();
            InitializeStrategies();
            InitializeStates();
        }
        
        protected virtual void Update()
        {
            if (MovementSystem != null)
            {
                MovementSystem.MovementStrategy.Move(transform, agent);
            }

            if (AttackSystem != null)
            {
                AttackSystem.EnemyAttackStrategy.Attack();
                
            }
            
            StateMachine.Execute(this);
        }
        //TODO добавить проверку приближения к игроку через статическую переменную его положения и крутить StateMachine /?в Update или событийно?/
        
        protected abstract void InitializeStrategies();
        protected abstract void InitializeStates();
    }
}

public enum CharacterType
{
    Neutral,
    Passive,
    Aggressive
}