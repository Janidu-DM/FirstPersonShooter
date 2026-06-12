using System;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _fireRate = 0.1f;
    [SerializeField] private float _fireRange = 100f;
    [SerializeField][Range(1 , 10000)] private float _impactForce = 10f;

    [Header("References")]
    [SerializeField] private Camera _fpsCam;
    

    public event Action OnShoot;
    public event Action<RaycastHit> OnHit;

    private float _nextTimeToFire = 0f;

    public void TryShoot()
    {
        if (Time.time >= _nextTimeToFire)
        {
            _nextTimeToFire = Time.time + _fireRate ;
            ExecuteShot();
        }
    }
    private void ExecuteShot()
    {
        OnShoot?.Invoke();


        RaycastHit hit;
        Ray ray = new Ray(_fpsCam.transform.position,_fpsCam.transform.forward);
        if (Physics.Raycast(ray,out hit, _fireRange))
        {
            OnHit?.Invoke(hit);


            if (hit.rigidbody != null) //AddingImpactForceto Rigidbody props to have fun
            {
                hit.rigidbody.AddForceAtPosition(-hit.normal * _impactForce, hit.point, ForceMode.Impulse); //more realistic
                //hit.rigidbody.AddForce(-hit.normal * _impactForce); //more cheap
            }


            IDamageble damageble = hit.collider.GetComponent<IDamageble>();
            if (damageble != null)
            {
                damageble.TakeDamage(_damage);
            }
            Debug.Log("Hit "+ hit.transform.name);

        }
    }

}
