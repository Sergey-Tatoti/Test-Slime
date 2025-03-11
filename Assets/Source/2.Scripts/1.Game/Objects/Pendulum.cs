using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField] private PendulumLine _pendulumLine;
    [SerializeField] private Transform _pointSpawnSlim;

    private Slime _activeSlime;
    private Coroutine _moveLine;
    private float _modifierForceImpulse;
    private bool _isSwinging;

    public void Initilialize(float moveSpeed, float leftAngle, float rightAngle, float modifierForceImpulse)
    {
        _modifierForceImpulse = modifierForceImpulse;
        _pendulumLine.SetValues(moveSpeed, leftAngle, rightAngle);
    }

    public void Activate(Slime slime)
    {
        _activeSlime = slime;
        _activeSlime.ResetChanges();
        _activeSlime.SetKinematic(true);
        _activeSlime.transform.SetParent(_pointSpawnSlim);
        _activeSlime.transform.localPosition = Vector3.zero;
        _activeSlime.transform.localEulerAngles = Vector3.zero;
        _activeSlime.gameObject.SetActive(true);

        if (_moveLine == null)
            _moveLine = StartCoroutine(_pendulumLine.UseMove());

        _isSwinging = true;
    }

    public void Deactivate()
    {
        DetachBall();
        StopCoroutine(_moveLine);

        _moveLine = null;
    }

    public void TryDetachSlime()
    {
        if (Input.GetMouseButtonDown(0) && _isSwinging)
            DetachBall();
    }

    void DetachBall()
    {
        float directionX = _pendulumLine.TimeDurationMove * _pendulumLine.CurrentSpeed * _modifierForceImpulse;

        if (!_pendulumLine.IsRightMove)
            directionX = -directionX;

        _isSwinging = false;
        _activeSlime.SetKinematic(false);
        _activeSlime.AddForce(new Vector2(directionX, -_pendulumLine.TimeDurationMove));
    }
}