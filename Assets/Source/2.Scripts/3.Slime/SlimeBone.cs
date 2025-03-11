using UnityEngine;

public class SlimeBone : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector3 _startPosition;
    private Quaternion _startRotation;

    public void Initialize()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _startPosition = transform.localPosition;
        _startRotation = transform.localRotation;
    }

    public void ResetBone()
    {
        _rigidbody2D.isKinematic = true;
        transform.localPosition = _startPosition;
        transform.localRotation = _startRotation;
        _rigidbody2D.isKinematic = false;
    }

    public void AddForce(Vector2 force) => _rigidbody2D.AddForce(force, ForceMode2D.Impulse);

    public void SetKinematic(bool isKinematic) => _rigidbody2D.isKinematic = isKinematic;
}