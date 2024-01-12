using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayRunners : MonoBehaviour
{
    public Transform[] runners;    // Массив бегунов
    public float moveSpeed = 5f;   // Скорость движения бегунов
    public float passDistance = 2f; // Дистанция, при которой передается эстафета

    private int currentRunnerIndex = 0;

    void Start()
    {
        SetNextRunner();
    }

    void Update()
    {
        MoveRunner();
    }

    void SetNextRunner()
    {
        // Вращение текущего бегуна к следующему
        if (currentRunnerIndex < runners.Length - 1)
            runners[currentRunnerIndex].LookAt(runners[currentRunnerIndex + 1]);
        else
            runners[currentRunnerIndex].LookAt(runners[0]);
    }

    void MoveRunner()
    {
        // Перемещение текущего бегуна
        runners[currentRunnerIndex].Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Проверка дистанции и передача эстафеты
        if (Vector3.Distance(runners[currentRunnerIndex].position, runners[(currentRunnerIndex + 1) % runners.Length].position) < passDistance)
        {
            currentRunnerIndex = (currentRunnerIndex + 1) % runners.Length;
            SetNextRunner();
        }
    }
}
