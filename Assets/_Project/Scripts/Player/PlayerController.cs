using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IPlayerInput _input;
    private PlayerMovementPhysics _movementPhysics;
    private PlayerLook _playerLook;

    [Header("The weapon container")]
    [SerializeField] private RaycastWeapon _weaponInstance;
    [SerializeField] private WeaponEffect _weaponEffect;
    private void Awake()
    {
        _input = GetComponent<IPlayerInput>();
        _movementPhysics = GetComponent<PlayerMovementPhysics>();
        _playerLook = GetComponent<PlayerLook>();
    }
    private void Update()
    {
        Vector2 movementInput = _input.GetMovementInput();

        Vector2 lookInput = _input.GetLookInput();

        _movementPhysics.Move(movementInput);
        _playerLook.Look(lookInput);

        if (_input.GetJumpInputDown())
        {
            _movementPhysics.Jump();
        }
        
        if (_input.GetShootInputDown() && _weaponInstance != null)
        {
            _weaponInstance.TryShoot();
        }
        if (_weaponEffect != null)
        {
            _weaponEffect.TryADS(_input.GetADSInputDown());
        }


    }
}
