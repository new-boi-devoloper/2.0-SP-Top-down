using EnemyScripts.EnemyManagement;

public class StateMachine
{
    public IState currentState;

    public void ChangeState(IState newState, EnemyBase enemy)
    {
        currentState?.Exit(enemy);
        currentState = newState;
        currentState?.Enter(enemy);
    }

    public void Execute(EnemyBase enemy)
    {
        currentState?.Execute(enemy);
    }
}