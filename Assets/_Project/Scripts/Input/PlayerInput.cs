using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour, IPlayerInput
{
    private PlayerInputActions _inputActions;
    private Vector2 _moveInput;
    private Vector2 _lookInput;
    private bool _jumpPressed;
    private bool _shootHolding;
    private bool _ADSHolding;

    private void Awake()
    {
        _inputActions = new PlayerInputActions();
    }
    private void OnEnable()
    {
        _inputActions.Player.Enable();
        _inputActions.Player.Jump.performed += OnJump_performed;
        _inputActions.Player.Shoot.performed += OnShoot_started;
        _inputActions.Player.Shoot.canceled += OnShoot_canceled;
        _inputActions.Player.ADS.performed += OnADS_started;
        _inputActions.Player.ADS.canceled += OnADS_canceled;
    }
    private void OnDisable()
    {
        _inputActions.Player.Disable();
        _inputActions.Player.Jump.performed -= OnJump_performed;
        _inputActions.Player.Shoot.performed -= OnShoot_started;
        _inputActions.Player.Shoot.canceled -= OnShoot_canceled;
        _inputActions.Player.ADS.performed -= OnADS_started;
        _inputActions.Player.ADS.canceled -= OnADS_canceled;
    }
    private void Update()
    {
        _moveInput = _inputActions.Player.Move.ReadValue<Vector2>();
        _lookInput = _inputActions.Player.Look.ReadValue<Vector2>();
    }
    private void LateUpdate()
    {
        _jumpPressed = false;
    }
    private void OnJump_performed(InputAction.CallbackContext obj)
    {
        _jumpPressed = true;
    }
    private void OnShoot_started(InputAction.CallbackContext obj)
    {
        _shootHolding = true;
    }
    private void OnShoot_canceled(InputAction.CallbackContext obj)
    {
        _shootHolding = false;
    }
    private void OnADS_started(InputAction.CallbackContext obj)
    {
        _ADSHolding = true;
    }
    private void OnADS_canceled(InputAction.CallbackContext obj)
    {
        _ADSHolding = false;
    }
    public Vector2 GetMovementInput() => _moveInput;
    public Vector2 GetLookInput() => _lookInput;
    public bool GetJumpInputDown() => _jumpPressed;
    public bool GetShootInputDown() => _shootHolding;
    public bool GetADSInputDown() => _ADSHolding;


}
