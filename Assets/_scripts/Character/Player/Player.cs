using System;
using System.Collections;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;


public class Player : Character
{
    private InputManager _manager;
    private Camera _eyesCamera;
    private float YRotation;
    [Header("Mouse Sensibility")] public float xSens;
    public float ySens;
    [Header("AmmoQuantity")] public int ammo;
    public int maxAmmoQuantity;

    private MuzzlePosition _bulletSpawnPoint;
    private Vector3 direction;
    [SerializeField] float elapsedTime;
    Coroutine shootCoroutine = null;

    public static Player instance;
    public static event Action<int> HealthChanged;

    public override int Health
    {
        set
        {
            base.Health = value;
            HealthChanged?.Invoke(value);
        }
    }

    // public int Health => _health;
    public int MaxHealth => _maxHealth;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Player!");
            return;
        }

        instance = this;
        elapsedTime = _fireRate;
    }

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnHit(1);
        }
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

        _eyesCamera.transform.localRotation = Quaternion.Euler(-YRotation, 0, 0);
        transform.Rotate(transform.up, rotation.x);
    }

    public void Shoot()
    {
        if (elapsedTime >= _fireRate)
        {
            var instanceOfBullet =
                Instantiate(_bulletPrefab, _bulletSpawnPoint.transform.position, Quaternion.identity);
            instanceOfBullet.damage = _atkDamage;
            instanceOfBullet.direction = _eyesCamera.transform.forward;
            instanceOfBullet.transform.rotation = _eyesCamera.transform.rotation;
            elapsedTime = 0;
        }

        if (elapsedTime == 0)
        {
            StartCoroutine(ResetFireTime());
        }
    }

    private IEnumerator ResetFireTime()
    {
        while (true)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= _fireRate)
            {
                break;
            }

            yield return null;
        }
    }

    private void UpdateStats(Stat type, float value)
    {
        switch (type)
        {
            case Stat.HEALTH:
                Health += (int)value;
                break;
            case Stat.AMMO:
                ammo += (int)value;
                break;
        }
    }

    public override void OnHit(int damage)
    {
         base.OnHit(damage);
    }
}