using UnityEngine;

namespace EnemyScripts.EnemySO
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Enemy/Enemy Config", order = 1)]
    public class EnemyConfig : ScriptableObject
    {
        public CharacterType characterType;
        public AttackType attackType;
        public MoveType moveType;
    }
}