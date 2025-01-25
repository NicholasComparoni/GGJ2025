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
    private float YRotation;
    [Header("Mouse Sensibility")]
    public float xSens;
    public float ySens;
    [Header("AmmoQuantity")] 
    public int ammo;
    public int maxAmmoQuantity;
    
    private MuzzlePosition _bulletSpawnPoint;
    private Vector3 direction;
    
    
    private void Start()
    {
        _manager = new(this);
        _rb = GetComponent<Rigidbody>();
        _bodyCollisionIdentifier = GetComponent<CapsuleCollider>();
        _eyesCamera = GetComponentInChildren<Camera>();
        _bulletSpawnPoint = GetComponentInChildren<MuzzlePosition>();
        
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
        _manager.CallShoot();

    }

    public void Movement(float vertical, float horizontal)
    {
        direction = transform.forward * vertical + transform.right * horizontal;

        direction = direction.normalized;

        transform.position += (Time.deltaTime * _movementSpeed) * direction;
    }

    public void RotateCamera(Vector3 rotation)
    {
        YRotation = Mathf.Clamp(YRotation + rotation.y, -80f, 45f);
        
        _eyesCamera.transform.localRotation = Quaternion.Euler(-YRotation, 0 ,0);
        transform.Rotate(transform.up ,rotation.x);

    }

    public void Shoot()
    {
        var instanceOfBullet =Instantiate(_bulletPrefab,_bulletSpawnPoint.transform.position, Quaternion.identity);
        instanceOfBullet.damage = _dmg;
        instanceOfBullet.direction = _eyesCamera.transform.forward;
        instanceOfBullet.transform.rotation = _eyesCamera.transform.rotation;
        
    }

    private void UpdateStats(Stat type, float value)
    {
        switch (type)
        {
            case Stat.HEALTH:
                _health += (int)value;
                break;
            case Stat.AMMO:
                ammo += (int)value;
                break;
        }
    }
}
