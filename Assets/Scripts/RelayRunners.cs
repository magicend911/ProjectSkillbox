using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayRunners : MonoBehaviour
{
    [SerializeField] private Transform[] runners;   
    [SerializeField] private float moveSpeed = 5f;  
    [SerializeField] private float passDistance = 2f; 

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
        if (currentRunnerIndex < runners.Length - 1)
            runners[currentRunnerIndex].LookAt(runners[currentRunnerIndex + 1]);
        else
            runners[currentRunnerIndex].LookAt(runners[0]);
    }

    void MoveRunner()
    {
        runners[currentRunnerIndex].Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Vector3.Distance(runners[currentRunnerIndex].position, runners[(currentRunnerIndex + 1) % runners.Length].position) < passDistance)
        {
            currentRunnerIndex = (currentRunnerIndex + 1) % runners.Length;
            SetNextRunner();
        }
    }
}
