using EnemyScripts.EnemyManagement;

public interface IState
{
    void Enter(EnemyBase enemy);
    void Execute(EnemyBase enemy);
    void Exit(EnemyBase enemy);
}