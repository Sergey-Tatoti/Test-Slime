using System.Collections;
using UnityEngine;

public class PendulumLine : MonoBehaviour
{
    private float _currentSpeed;
    private float _moveSpeed;
    private float _leftAngle;
    private float _rightAngle;
    private bool _isRightMove = true;
    public float _timeDurationMove = 0;
    private Rigidbody2D _rigidBody2D;

    public float TimeDurationMove => _timeDurationMove;
    public float CurrentSpeed => _currentSpeed;
    public bool IsRightMove => _isRightMove;

    public void SetValues(float moveSpeed, float leftAngle, float rightAngle)
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();

        _moveSpeed = moveSpeed;
        _leftAngle = leftAngle;
        _rightAngle = rightAngle;
        _currentSpeed = _moveSpeed;
    }

    public void StopMove(bool isStop)
    {
        _timeDurationMove = 0;
        _currentSpeed = isStop ? 0 : _moveSpeed;
    }

    public IEnumerator UseMove()
    {
        StopMove(false);

        while (true)
        {
            _timeDurationMove += Time.deltaTime;

            TryChangeDirection();
            Move();

            yield return null;
        }
    }

    private void TryChangeDirection()
    {
        if (transform.rotation.z > _rightAngle)
            ChangeDirection(false);

        if (transform.rotation.z < _leftAngle)
            ChangeDirection(true);
    }

    private void ChangeDirection(bool isRight)
    {
        _timeDurationMove = 0;
        _isRightMove = isRight;
    }

    private void Move()
    {
        if (_isRightMove)
            _rigidBody2D.angularVelocity = _currentSpeed;
        else
            _rigidBody2D.angularVelocity = -_currentSpeed;
    }
}