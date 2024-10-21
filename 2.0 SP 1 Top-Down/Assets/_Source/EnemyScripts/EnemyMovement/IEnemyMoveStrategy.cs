using UnityEngine;
using UnityEngine.AI;

public interface IEnemyMovementStrategy
{
    void Move(Transform transform, NavMeshAgent agent);
}