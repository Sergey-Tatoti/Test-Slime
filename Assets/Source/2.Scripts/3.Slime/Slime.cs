using Spine.Unity;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private const string IdleAnimationName = "Idle";
    private const string HitAnimationName = "Landing and lifting";

    public enum Type { Blue, Green, Yellow, Red}

    [SerializeField] private Type _typeSlime;
    [SerializeField] private List<SlimeBone> _slimeBones;
    [SerializeField] private SkeletonAnimation _faceAnimation;

    private Rigidbody2D _rigidBody2D;

    public Type TypeSlime => _typeSlime;

    private bool _canShowHitFace = true;

    public void Initialize()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();

        for (int i = 0; i < _slimeBones.Count; i++) { _slimeBones[i].Initialize(); }
    }

    public void ResetChanges()
    {
        for (int i = 0; i < _slimeBones.Count; i++) { _slimeBones[i].ResetBone(); }
    }

    public void SetKinematic(bool isKinematic)
    {
        _rigidBody2D.isKinematic = isKinematic;

        for (int i = 0; i < _slimeBones.Count; i++) { _slimeBones[i].SetKinematic(isKinematic); }
    }

    public void AddForce(Vector2 force)
    {
        _rigidBody2D.AddForce(force, ForceMode2D.Impulse);

        for (int i = 0; i < _slimeBones.Count; i++) { _slimeBones[i].AddForce(force); }
    }

    private void CooldownShowHitFace()
    {
        _canShowHitFace = true;
        _faceAnimation.AnimationName = IdleAnimationName;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_canShowHitFace && collision.relativeVelocity.x > 0.3f && collision.relativeVelocity.y > 0.3f)
        {
            _canShowHitFace = false;
            _faceAnimation.AnimationName = HitAnimationName;
            Invoke(nameof(CooldownShowHitFace), 1f);
        }
    }
}