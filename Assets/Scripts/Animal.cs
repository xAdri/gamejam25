using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] private GameObject map;
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private List<Vector3> targetPositions;
    [SerializeField] private Vector3 currentPos;
    [SerializeField] private Vector3 nextPos;
    [SerializeField] private GameObject targetToSearch;
    PositionGenerator posGen;
    float moveSpeed = 5f;
    float rotationSpeed = 10f;

    void Start()
    {
        posGen = new PositionGenerator();
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
        InstantiateParticles();
    }

    private void MoveToNextPosition()
    {
        Vector3 direction = (nextPos - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if (Vector3.Distance(gameObject.transform.position, nextPos) <= 0.5f)
        {
            NextPosition();
            InstantiateParticles();
        }
    }

    private void NextPosition()
    {
        nextPos = targetPositions[0];
        targetPositions.RemoveAt(0);
        Destroy(targetToSearch, 0);
    }

    private void InstantiateParticles()
    {
        targetToSearch = Instantiate(targetPrefab, nextPos, Quaternion.identity);
    }
}
