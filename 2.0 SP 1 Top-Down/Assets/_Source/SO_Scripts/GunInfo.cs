using UnityEngine;

[CreateAssetMenu(fileName = "GunData", menuName = "GunSO/GunData")]
public class GunInfo : ScriptableObject
{
    public GameObject weaponPrefab;
    public float weaponCooldown;
    public int weaponDamage;
    public float weaponRange;
    public float bulletSpeed;
}