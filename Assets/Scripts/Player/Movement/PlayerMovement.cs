using UnityEngine;

public sealed class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    
    [Header("Player settings")]
    [SerializeField, Range(0, 10)] private float walkingSpeed;
    [SerializeField, Range(0, 10)] private float runningSpeed;
    [SerializeField, Range(0, -10)] private float gravity;
    [SerializeField, Range(0, 1)] private float groundDistance;

    private Vector3 _moveDirection;
    private Vector3 _velocity;
    private float _currentMovementSpeed;
    private float _horizontal;
    private float _vertical;
    private bool _isGrounded;

    private void Update()
    {
        SetInput();
        ApplyGravity();
        ApplyRunning();
        SetMoveDirection();
    }

    private void SetInput()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
    }

    private void ApplyGravity()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (_isGrounded && _velocity.y < 0) _velocity.y = 0f;
        _velocity.y += gravity * Time.deltaTime;
    }

    private void SetMoveDirection()
    {
        _moveDirection = (transform.right * _horizontal + transform.forward * _vertical) * _currentMovementSpeed;
        _moveDirection.y = _velocity.y;
        
        characterController.Move(_moveDirection * Time.deltaTime);
    }

    private void ApplyRunning() => _currentMovementSpeed = Input.GetKey(KeyCode.LeftShift) ? runningSpeed : walkingSpeed;
}
