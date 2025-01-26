using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] private GameObject map;
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private List<Vector3> targetPositions;
    [SerializeField] private Vector3 currentPos;
    [SerializeField] private Vector3 nextPos;

    void Start()
    {
        GenerateRandomPositions();
    }

    private void Update()
    {
        MoveToNextPosition();
    }

    private void GenerateRandomPositions()
    {
        PositionGenerator posGen = new PositionGenerator();

        for (int i = 0; i < 50; i++)
        {
            targetPositions.Add(posGen.GetRandomPointInBounds(map));
        }

        nextPos = targetPositions[0];
    }

    private void MoveToNextPosition()
    {
        // Hacer que se mueva con una variable de velocidad definida como speed hasta llegar al otro punto
        if (Vector3.Distance(gameObject.transform.position, currentPos) <= 0.1f)
        {
            InstantiateParticles();
            NextPosition();
        }
    }

    private void NextPosition()
    {
        nextPos = targetPositions[0];
        targetPositions.RemoveAt(0);
    }

    private void InstantiateParticles()
    {
        Instantiate(targetPrefab, nextPos, Quaternion.identity);
    }
}
