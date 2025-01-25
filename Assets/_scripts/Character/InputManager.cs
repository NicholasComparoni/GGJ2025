using Unity.VisualScripting;
using UnityEngine;

public class InputManager
{
    private Player _player;
    private float _horizontal;
    private float _vertical;
    private Vector3 currentRotation;
    public InputManager(Player player)
    {
        _player = player;
    }

    public void UpdateMovement()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        if (_vertical != 0 || _horizontal != 0)
        {
             _player.Movement(_vertical, _horizontal);
        }
    }

    public void UpdateCameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * _player.xSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _player.ySens * Time.deltaTime;
        
        currentRotation = new Vector3(mouseX, mouseY, 0);

        _player.RotateCamera(currentRotation);
    }

    public void CallShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _player.Shoot();
        }
    }
}