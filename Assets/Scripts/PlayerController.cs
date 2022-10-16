using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int IsJumping = Animator.StringToHash("IsJumping");

    private Rigidbody2D _playerRb;
    private Animator _animator;

    private float _maxForce = 400;
    private float _jumpForce;
    private bool _playerInGround = true;

    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (_playerInGround && !GameManager.Instance.IsGameOver)
        {
            //TODO: Add abstraction
            if (Input.GetKey(KeyCode.Space))
            {
                //TODO: Add Ui
                _jumpForce += (_jumpForce <= _maxForce ? 1000f : 0) * Time.deltaTime;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                PlayerJump();
                _jumpForce = 0;
            }
        }

        if (GameManager.Instance.IsGameOver)
        {
            SetPlayerSpeed(0);
        }
        else
        {
            SetPlayerSpeed(1);
        }
    }

    private void PlayerJump()
    {
        _playerRb.AddForce(Vector2.up * _jumpForce);
        _animator.SetBool(IsJumping, true);
        _playerInGround = false;
    }

    private void SetPlayerSpeed(float value)
    {
        _animator.SetFloat(Speed, value);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            _animator.SetBool(IsJumping, false);
            _playerInGround = true;
        }
    }
}