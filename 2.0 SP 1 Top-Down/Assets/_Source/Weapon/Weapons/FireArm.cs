using UnityEngine;

public class FireArm : AbstractWeapon
{
    [field: SerializeField] public GunInfo GunInfo { get; private set; }
    [field: SerializeField] public Transform SpawnPosition { get; private set; }
    [field: SerializeField] public Bullet BulletPrefab { get; private set; }

    public override void Shoot()
    {
        // Create the projectile with the correct rotation
        var bullet = Bullet.Create(
            GunInfo.bulletSpeed,
            GunInfo.weaponDamage,
            GunInfo.weaponRange,
            SpawnPosition.position,
            transform.rotation,
            BulletPrefab);
    }
}