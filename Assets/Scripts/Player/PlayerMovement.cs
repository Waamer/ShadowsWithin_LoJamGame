using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float _moveSpeed = 5f;
    private float _currentSpeedMultiplier = 1f;
    private Vector2 _movement;
    private Rigidbody2D _rb;
    private Animator _animator;

    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";
    private const string _lastHorizontal = "LastHorizontal";
    private const string _lastVertical = "LastVertical";

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _movement.Set(InputManager.Movement.x, InputManager.Movement.y);

        _rb.linearVelocity = _movement * _moveSpeed * _currentSpeedMultiplier;

        _animator.SetFloat(_horizontal, _movement.x);
        _animator.SetFloat(_vertical, _movement.y);

        if (_movement != Vector2.zero)
        {
            _animator.SetFloat(_lastHorizontal, _movement.x);
            _animator.SetFloat(_lastVertical, _movement.y);
        }
    }

    public void SetSpeedMultiplier(float multiplier)
    {
        _currentSpeedMultiplier = multiplier;
    }
}
