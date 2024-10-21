using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    private IDirectionController directionController;

    private void Start()
    {
        // Получаем компонент, который реализует интерфейс IDirectionController
        directionController = GetComponent<IDirectionController>();

        if (directionController == null) Debug.LogError("No IDirectionController found on the object.");
    }

    private void Update()
    {
        // Получаем позицию мыши в мировых координатах
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Устанавливаем z в 0 для 2D

        // Вычисляем направление к мыши
        Vector2 direction = (mousePos - transform.position).normalized;

        // Обновляем направление объекта
        directionController?.UpdateDirection(direction);
    }
}