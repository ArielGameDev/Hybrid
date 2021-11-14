using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{

    [SerializeField]
    GameObject _projectile;

    [SerializeField]
    Transform _shootFrom;

    [SerializeField]
    FireEffects _onShoot;



    void Start()
    {
        if (_projectile == null || _shootFrom == null)
        {
            Debug.LogError("Not all fields are set! Disabling component");
            return;
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();
    }

    void Shoot()
    {
        Transform newTrs = Instantiate(_projectile, _shootFrom.position,_shootFrom.rotation).transform;

        if(_onShoot != null)
            _onShoot.Apply(newTrs);
    }
}
