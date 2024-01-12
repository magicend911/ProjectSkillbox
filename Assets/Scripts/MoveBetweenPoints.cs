using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    public Vector3[] waypoints; // Массив точек, по которым будет двигаться объект
    public float moveSpeed = 5f;   // Скорость движения объекта

    private bool forward = true;
    private int currentWaypoint = 0;

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (waypoints.Length == 0)
            return;

        // Определение направления движения
        if (forward)
        {
            // Перемещение объекта к текущей точке
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint], moveSpeed * Time.deltaTime);

            // Если объект достиг текущей точки, переход к следующей
            if (Vector3.Distance(transform.position, waypoints[currentWaypoint]) < 0.1f)
            {
                currentWaypoint++;

                // Если достигнута последняя точка, начинаем движение в обратном направлении
                if (currentWaypoint == waypoints.Length)
                {
                    forward = false;
                    currentWaypoint = waypoints.Length - 1;
                }
            }
        }
        else
        {
            // Перемещение объекта к предыдущей точке
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint], moveSpeed * Time.deltaTime);

            // Если объект вернулся к начальной точке, начинаем движение вперед
            if (Vector3.Distance(transform.position, waypoints[currentWaypoint]) < 0.1f)
            {
                currentWaypoint--;

                // Если достигнута первая точка, начинаем движение вперед
                if (currentWaypoint < 0)
                {
                    forward = true;
                    currentWaypoint = 0;
                }
            }
        }
    }
}
