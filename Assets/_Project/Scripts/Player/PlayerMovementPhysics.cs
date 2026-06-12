using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementPhysics : MonoBehaviour
{
    [Header("MovementSettings")]
    [SerializeField] private float _moveSpeed = 7f;
    [SerializeField] private float _gravity = -19.75f;
    [SerializeField] private float _jumpHeight = 2f;

    [Header("GroundCheckSettings")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private LayerMask _groundMask;

    private CharacterController _characterController;
    private Vector3 _velocity;
    private bool _isGrounded;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }
    public void Move(Vector2 input)
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position,_groundDistance,_groundMask);

        if (_isGrounded && _velocity.y < 0) 
        {
            _velocity.y = -2f;
        }

        Vector3 moveDirection = transform.right * input.x + transform.forward * input.y;
        _characterController.Move(moveDirection * _moveSpeed * Time.deltaTime);

        _velocity.y += _gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);

    }
    public void Jump()
    {
        if (_isGrounded)
        {
            _velocity.y = Mathf.Sqrt(-2f *_gravity* _jumpHeight);

        }
    }
}
