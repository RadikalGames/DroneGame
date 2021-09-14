using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(PlayerInput))]
public class DroneControlsListener : MonoBehaviour
{
    #region Private Variables
    private Vector2 rotational;
    private float upandown;
    private PlayerShootController psc;
    public Vector2 Rotational { get => rotational;}
    public float Upandown { get => upandown;  }
    #endregion
    private void Start()
    {
        psc = GetComponent<PlayerShootController>();
    }

    private void OnRotational(InputValue val)
    {
        rotational = val.Get<Vector2>();
    }

    private void OnUpandDown(InputValue val)
    {
        upandown = val.Get<float>();
    }
    private void OnShoot()
    {
        psc.Shoot();
    }
}
