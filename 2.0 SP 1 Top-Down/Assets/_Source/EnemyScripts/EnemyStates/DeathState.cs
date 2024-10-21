using EnemyScripts.EnemyManagement;
using UnityEngine;

namespace _Source.Scripts.EnemyScripts.EnemyStates
{
    public class DeathState : IState
    {
        public void Enter(EnemyBase enemy)
        {
            Debug.Log("Entering Death IState");
            // Вызов анимации смерти
            enemy.GetComponent<Animator>().SetTrigger("Die");
        }

        public void Execute(EnemyBase enemy)
        {
        }

        public void Exit(EnemyBase enemy)
        {
            Debug.Log("Exiting Death IState");
        }
    }
}