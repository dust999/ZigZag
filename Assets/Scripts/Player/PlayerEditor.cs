using UnityEngine;

public class PlayerEditor : Player
{
    [SerializeField] private bool _canEnableKeys = false;

    private void EnableKeys()
    {
        _playerMovementVector = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {     
            _playerMovementVector.x = -1;
            _playerMovementVector.z = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _playerMovementVector.x -= 1;
            _playerMovementVector.z -= 1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _playerMovementVector.x = 1;
            _playerMovementVector.z = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _playerMovementVector.x = 1;
            _playerMovementVector.z = -1;
        }

        Move (_playerMovementVector);
    }

    protected override void Update()
    {
        if(_canEnableKeys)
            EnableKeys();
        else
            base.Update();
    }
}
