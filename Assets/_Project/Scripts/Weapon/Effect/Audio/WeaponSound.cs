using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class WeaponSound : MonoBehaviour
{
    [Header("Weapon Shooting Audio Settings")]
    [SerializeField] private AudioClip _shootAudioClip;
    [SerializeField][Range(0, 1)] private float _volume = 0.8f;
    [SerializeField][Range(0, 1)] private float _pitchRandomness = 0.05f;

    private RaycastWeapon _weaponLogic;
    private AudioSource _audioSource;
    private float _defaultPitch;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _weaponLogic = GetComponent<RaycastWeapon>();
        _defaultPitch = _audioSource.pitch;
        _audioSource.spatialBlend = 0f; //making shooting sound 2D 
        _audioSource.playOnAwake = false;
    }

    private void OnEnable()
    {
        _weaponLogic.OnShoot += PlayShootSound;
    }
    private void OnDisable()
    {
        _weaponLogic.OnShoot -= PlayShootSound;
    }
    private void PlayShootSound()
    {
        if(_audioSource != null)
        {
            _audioSource.pitch = _defaultPitch + Random.Range(-_pitchRandomness,_pitchRandomness);
            _audioSource.PlayOneShot(_shootAudioClip, _volume);
        }

        return;
    }
}
