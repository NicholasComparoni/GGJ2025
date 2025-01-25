using UnityEngine;

public class CharacterPlayer : Character
{
    private InputManager _manager;
    private Camera _eyesCamera;
    private float _xSensibility;
    private float _ySensibility;
    
    private void Start()
    {
        _manager = new(this);
        _rb = GetComponent<Rigidbody>();
        _bodyCollisionIdentifier = GetComponent<Collider>();
        _eyesCamera = GetComponentInChildren<Camera>();
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        _manager.UpdateMovement();
        _manager.UpdateCameraRotation();
    }

    public void Movement(float vertical, float horizontal)
    {
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        this.transform.position += (Time.deltaTime * _movementSpeed )* direction;
    }

    public void RotateCamera(Vector3 rotation)
    {
        var clampedYRotation = Mathf.Clamp(rotation.x, -90f, 90f);
        var clampedXRotation = Mathf.Clamp(rotation.x, -90f, 90f);
        _eyesCamera.transform.rotation = Quaternion.Euler(-rotation.y, rotation.x ,0 );
    }

    //private void UpdateStats(enum StatType, float value)
}
