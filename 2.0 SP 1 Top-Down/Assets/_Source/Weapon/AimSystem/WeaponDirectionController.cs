using UnityEngine;

public class WeaponDirectionController : MonoBehaviour, IDirectionController
{
    private bool _isFlipped;

    public void UpdateDirection(Vector2 direction)
    {
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Определяем, на какой стороне находится мышка
        if (direction.x < 0 && !_isFlipped)
        {
            _isFlipped = true;
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        }
        else if (direction.x >= 0 && _isFlipped)
        {
            _isFlipped = false;
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        }

        // Поворачиваем оружие
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}