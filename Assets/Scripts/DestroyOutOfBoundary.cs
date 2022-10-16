using UnityEngine;

public class DestroyOutOfBoundary : MonoBehaviour
{
    private float _xBoyndary = -10;
    
    void Update()
    {
        if (transform.position.x < _xBoyndary)
        {
            Destroy(gameObject);
        }
    }
}