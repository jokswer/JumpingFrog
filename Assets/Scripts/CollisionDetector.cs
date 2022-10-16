using System.Collections;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private static readonly int IsHit = Animator.StringToHash("IsHit");
    private static readonly int IsJumping = Animator.StringToHash("IsJumping");

    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle"))
        {
            _animator.SetBool(IsJumping, false);
            _animator.SetBool(IsHit, true);
            StartCoroutine(HitOutAnimation());
            GameManager.Instance.SetGameOver();
        }
        else if (col.CompareTag("SafeZone"))
        {
            GameManager.Instance.IncrementScore();
        }
    }

    private IEnumerator HitOutAnimation()
    {
        yield return new WaitForSeconds(1f);
        _animator.SetBool(IsHit, false);
    }
}