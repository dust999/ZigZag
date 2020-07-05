using UnityEngine;

[RequireComponent (typeof(ObjectRigidBody))]
public class Player : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed = 0.1f;

    private ObjectRigidBody _playerRigidBody = null;
    
    private bool _isPlayerActivated = false;
    private Direction _playerDirection = Direction.Forward;
    protected Vector3 _playerMovementVector;

    private void Awake()
    {
        _playerRigidBody = GetComponent<ObjectRigidBody>();
        ResetPlayer();
    }

    public float GetSpeed()
    {
        return _speed;
    }

    protected virtual void UserInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!_isPlayerActivated)
                _isPlayerActivated = true;
            else
                _playerDirection = SwitchDirection();
            
            _playerMovementVector.x = _playerDirection == Direction.Right ? 1 : -1;
        }
    }

    protected virtual void Update()
    {
        UserInput();

        if (_isPlayerActivated) 
            Move(_playerMovementVector);
    }

    private Direction SwitchDirection()
    {
        return _playerDirection == Direction.Right ? Direction.Forward : Direction.Right;
    }

    public void Move(Vector3 direction)
    {
       transform.position += direction * _speed;
    }

    public void PlayerFall()
    {
        //Debug.Break();
        _playerRigidBody.FallAway(_playerMovementVector);
        enabled = false;
    }

    public void ResetPlayer()
    {
        enabled = true;
        transform.position = Vector3.zero;
        _playerDirection = Direction.Forward;
        _playerMovementVector = new Vector3(1, 0, 1);
        _isPlayerActivated = false;
    }
}
