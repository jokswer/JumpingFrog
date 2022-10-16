using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;

    void Update()
    {
        if (!GameManager.Instance.IsGameOver)
        {
            transform.Translate(Vector3.left * (Time.deltaTime * speed));
        }
    }
}