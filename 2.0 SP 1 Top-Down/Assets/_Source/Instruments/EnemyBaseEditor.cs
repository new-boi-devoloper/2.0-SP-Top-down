using EnemyScripts.Enemies;
using EnemyScripts.EnemyManagement;
using UnityEditor;
using UnityEngine;

namespace _Source.Scripts.Instruments
{
    [CustomEditor(typeof(RaiderEnemy))]
    public class EnemyBaseEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            EnemyBase enemyBase = (EnemyBase)target;

            EditorGUILayout.LabelField("Enemy Setup", EditorStyles.boldLabel);
            enemyBase.EnemyCharacter = (CharacterType)EditorGUILayout.EnumPopup("Character Type", enemyBase.EnemyCharacter);

            enemyBase.isMoving = EditorGUILayout.Toggle("Is Moving", enemyBase.isMoving);
            if (enemyBase.isMoving)
            {
                enemyBase.moveType = (MoveType)EditorGUILayout.EnumPopup("Move Type", enemyBase.moveType);
            }

            enemyBase.isAttacking = EditorGUILayout.Toggle("Is Attacking", enemyBase.isAttacking);
            if (enemyBase.isAttacking)
            {
                enemyBase.attackType = (AttackType)EditorGUILayout.EnumPopup("Attack Type", enemyBase.attackType);
            }

            enemyBase.isAlerting = EditorGUILayout.Toggle("Is Alerting", enemyBase.isAlerting);

            if (GUI.changed)
            {
                EditorUtility.SetDirty(enemyBase);
            }
        }
        
    }
}