using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private float repeatRate = 3f;

    private float _time = 5f;
    private float _yBoundaryTop = -0.2f;
    private float _yBoundaryBottom = 0.6f;

    void Update()
    {
        if (GameManager.Instance.IsGameOver)
        {
            CancelInvoke();
        }
        else
        {
            if (!IsInvoking(nameof(Spawn)))
            {
                InvokeRepeating(nameof(Spawn), _time, repeatRate);
            }
        }
    }

    private void Spawn()
    {
        var y = Random.Range(_yBoundaryTop, _yBoundaryBottom);
        var position = new Vector3(5f, y, 0);
        Instantiate(obstacle, position, obstacle.transform.rotation);
    }
}