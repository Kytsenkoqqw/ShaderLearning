using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость перемещения камеры
    public float sensitivity = 2f;

    void Update()
    {
        // Получаем входные данные о нажатых клавишах для перемещения
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Вычисляем вектор перемещения на основе входных данных
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed * Time.deltaTime;

        // Преобразуем вектор перемещения в систему координат глобальных координат камеры
        movement = transform.TransformDirection(movement);

        // Производим перемещение камеры
        transform.position += movement;
        
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Вычисляем новые углы поворота камеры на основе движения мыши
        float rotationX = transform.localEulerAngles.y + mouseX * sensitivity;
        float rotationY = transform.localEulerAngles.x - mouseY * sensitivity;

        // Ограничиваем угол Y, чтобы камера не могла перевернуться
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        // Устанавливаем новый угол поворота камеры
        transform.localEulerAngles = new Vector3(rotationY, rotationX, 0);
    }
}
