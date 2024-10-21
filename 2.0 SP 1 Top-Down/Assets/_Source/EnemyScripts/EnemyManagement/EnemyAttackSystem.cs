using System;
using EnemyScripts.EnemyAttack;
using UnityEngine;

namespace EnemyScripts.EnemyManagement
{
    public class EnemyAttackSystem
    {
        public AttackType attackType { get; private set; }
        public IEnemyAttackStrategy EnemyAttackStrategy { get; private set; }

        public EnemyAttackSystem(GameObject gameObject, AttackType chosenAttackType)
        {
            attackType = chosenAttackType;
            switch (chosenAttackType)
            {
                case AttackType.Distant:
                    EnemyAttackStrategy = new DistantEnemyAttackStrategy();
                    break;
                case AttackType.Melee:
                    EnemyAttackStrategy = new MeleeEnemyAttackStrategy();
                    break;
                default:
                    throw new Exception($"not valid attack type on {gameObject}");
            }
        }
    }
}

public enum AttackType
{
    Distant,
    Melee
}