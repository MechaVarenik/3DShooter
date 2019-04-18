using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    // Чувствительность мышки по двум осям
    [SerializeField]
    private float sensitivityX = 1.0f, sensitivityY = 1.0f;

    // Минимальное и максимальное вращение по оси X
    [SerializeField]
    private float minX = -90.0f, maxX = 90.0f;

    // Опции поворота
    private enum Options { X, Y, XandY }

    // Выбранная опция поворота
    [SerializeField]
    private Options options;

    // Текущий поворот
    private Quaternion targetRot;

    void Start()
    {
        // Сохраняем текущий поворот
        targetRot = transform.rotation;
    }

    void Update()
    {
        Cursor.visible = false;
        // Получаем значения поворота мыши и умножаем на чувствительность поворота
        float rotY = Input.GetAxis("Mouse X") * sensitivityX;
        float rotX = Input.GetAxis("Mouse Y") * sensitivityY;

        if (rotX >= maxX) rotX = maxX;
            
        // Определяем необходимую ось вращения
        if (options == Options.X)
            // Устанавливаем текущий поворот на необходимый угол
            targetRot *= Quaternion.Euler(-rotX, 0.0f, 0.0f);
        else if (options == Options.Y)
            targetRot *= Quaternion.Euler(0.0f, rotY, 0.0f);
        else if (options == Options.XandY)
            targetRot *= Quaternion.Euler(-rotX, rotY, 0.0f);

        // Поворачиваем объект
        transform.localRotation = targetRot;
    }
}