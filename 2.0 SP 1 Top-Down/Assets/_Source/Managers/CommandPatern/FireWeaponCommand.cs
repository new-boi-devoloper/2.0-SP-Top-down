public class FireWeaponCommand : ICommand
{
    private readonly WeaponSlot _weaponSlot;

    public FireWeaponCommand(WeaponSlot weaponSlot)
    {
        _weaponSlot = weaponSlot;
    }

    public void Execute()
    {
        _weaponSlot.FireCurrentFireWeapon();
    }
}