using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    [field: SerializeField] public GameObject CurrentFireWeapon { get; private set; }

    private void FixedUpdate()
    {
        // Если оружие не является дочерним объектом, сделаем его таковым
        if (CurrentFireWeapon != null && CurrentFireWeapon.transform.parent != transform)
            SetWeaponAsChild(CurrentFireWeapon);

        // Устанавливаем позицию оружия в позицию WeaponSlot
        if (CurrentFireWeapon != null) CurrentFireWeapon.transform.position = transform.position;
    }

    private void SetWeaponAsChild(GameObject weapon)
    {
        if (weapon != null)
        {
            weapon.transform.SetParent(transform);
            weapon.transform.localPosition = Vector3.zero; // Устанавливаем локальную позицию в (0, 0, 0)
            weapon.transform.localRotation = Quaternion.identity; // Устанавливаем локальный поворот в (0, 0, 0)
        }
    }

    public void SetCurrentFireWeapon(GameObject weapon)
    {
        CurrentFireWeapon = weapon;
        SetWeaponAsChild(weapon);
    }

    public void FireCurrentFireWeapon()
    {
        Debug.Log("Command Recievd");
        if (CurrentFireWeapon != null)
        {
            var abstractFireWeapon = CurrentFireWeapon.GetComponent<AbstractWeapon>();

            if (abstractFireWeapon != null)
            {
                abstractFireWeapon.Shoot();
                Debug.Log("Weapon Shoot Invoked");
            }
            else
            {
                Debug.LogWarning("CurrentFireWeapon does not have an AbstractWeapon component.");
            }
        }
        else
        {
            Debug.Log("No Weapon assigned");
        }
    }

    public void ClearCurrentFireWeapon()
    {
        if (CurrentFireWeapon != null)
        {
            CurrentFireWeapon.transform.SetParent(null); // Отсоединяем оружие от WeaponSlot
            CurrentFireWeapon = null;
        }
    }
}