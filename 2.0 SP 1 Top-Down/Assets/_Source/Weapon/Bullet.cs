using _Source.Scripts.Instruments;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private Vector3 _direction;
    private float _lifetime;
    private float _moveSpeed;
    private float _projectileDamage;
    private float _projectileRange;

    private Vector3 _startPosition;

    private void Update()
    {
        MoveProjectile();
        DetectFireDistance();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (LayerMaskUtil.ContainsLayer(LayerMask.GetMask("Player"), other.gameObject))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    public static Bullet Create(float moveSpeed, float projectileDamage, float projectileRange, Vector3 position,
        Quaternion rotation, Bullet bulletPrefab)
    {
        var bullet = Instantiate(bulletPrefab, position, rotation);
        bullet.UpdateStats(moveSpeed, projectileDamage, projectileRange, position);
        return bullet;
    }

    public void UpdateStats(float moveSpeed, float projectileDamage, float projectileRange, Vector3 position)
    {
        _moveSpeed = moveSpeed;
        _projectileDamage = projectileDamage;
        _projectileRange = projectileRange;

        _startPosition = position;
        Debug.Log("Spawn position changed");
    }

    private void MoveProjectile()
    {
        transform.Translate(-Vector3.right * (_moveSpeed * Time.deltaTime));
    }

    private void DetectFireDistance()
    {
        if (Vector3.Distance(transform.position, _startPosition) > _projectileRange) Destroy(gameObject);
    }
}