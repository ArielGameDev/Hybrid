using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSwitcher : MonoBehaviour
{

    [SerializeField]
    CameraFollow _camera;

    [SerializeField]
    Player _mainUnit;

    [SerializeField]
    Player _secondaryUnit;


    Player _activePlayer;


    void Start()
    {
        if (_mainUnit == null || _secondaryUnit == null || _camera == null){
            Debug.LogError("Not all fields are set! Disabling component");
            this.enabled = false;
            return;
        }

        _activePlayer = _mainUnit;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            HandlePlayerSwitch();
    }

    void HandlePlayerSwitch()
    {
        _activePlayer.enabled = false;
        if(_activePlayer == _mainUnit)
            _activePlayer = _secondaryUnit;
        else
            _activePlayer = _mainUnit;

        _activePlayer.enabled = true;
        _camera.SetTarget(_activePlayer.transform);
    }
}
