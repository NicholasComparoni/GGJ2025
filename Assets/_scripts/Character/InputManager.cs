using Unity.VisualScripting;
using UnityEngine;

public class InputManager
{
    private CharacterPlayer _player;
    private float _horizontal;
    private float _vertical;

    public InputManager(CharacterPlayer player)
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
        var mouseMovement = Input.mousePosition;
        _player.RotateCamera(mouseMovement);
    }
}