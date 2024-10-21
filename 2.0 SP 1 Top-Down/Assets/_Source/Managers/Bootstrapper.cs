using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private InputListener inputListener;
    [SerializeField] private Player player;
    [SerializeField] private WeaponSlot weaponSlot;
    
    private PlayerCombatCommands _playerCombatCommands;
    private PlayerControls _playerControls;

    private PlayerInvoker _playerInvoker;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _playerMovement = new PlayerMovement();
        _playerCombatCommands = new PlayerCombatCommands();

        _playerInvoker = new PlayerInvoker(player, _playerMovement, _playerCombatCommands);

        AttackCommandsInitialize();

        // Активируем контроллер ввода
        _playerControls.Enable();

        inputListener.Initialize(_playerControls, _playerInvoker);
    }

    private void OnDestroy()
    {
        _playerControls.Disable();
    }

    private void AttackCommandsInitialize()
    {
        // Регистрация команд
        _playerCombatCommands.RegisterCommand("FireWeapon", new FireWeaponCommand(weaponSlot));
    }
}