using System;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;


public class CharacterPlayer : Character
{
    private InputManager _manager;
    private Camera _eyesCamera;
    public float xSens;
    public float ySens;
    private float YRotation;
    private void Start()
    {
        _manager = new(this);
        _rb = GetComponent<Rigidbody>();
        _bodyCollisionIdentifier = GetComponent<CapsuleCollider>();
        _eyesCamera = GetComponentInChildren<Camera>();
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        _manager.UpdateMovement();
    }

    private void Update()
    {
        _manager.UpdateCameraRotation();

    }

    public void Movement(float vertical, float horizontal)
    {
        Vector3 direction = transform.forward * vertical + transform.right * horizontal;

        direction = direction.normalized;

        transform.position += (Time.deltaTime * _movementSpeed) * direction;
    }

    public void RotateCamera(Vector3 rotation)
    {
        YRotation = Mathf.Clamp(YRotation + rotation.y, -80f, 45f);
        
        _eyesCamera.transform.localRotation = Quaternion.Euler(-YRotation, 0 ,0);
        transform.Rotate(transform.up ,rotation.x);

    }

    //private void UpdateStats(enum StatType, float value)
}
