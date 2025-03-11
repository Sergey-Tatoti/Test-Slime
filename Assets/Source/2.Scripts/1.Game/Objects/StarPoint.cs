using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class StarPoint : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleShow;
    [SerializeField] private TMP_Text _textScore;

    private float _maxSize;
    private float _durationChangeScale;
    private float _durationMoveStar;
    private Vector2 _positionMove;
    private Vector2 _positionSpawn;

    public event UnityAction EndedAnimationGetScore;

    public void Initialize(float maxSize, float durationChangeScale, float durationMove, Vector2 positionMove, Vector2 positionSpawn)
    {
        _maxSize = maxSize;
        _durationChangeScale = durationChangeScale;
        _durationMoveStar = durationMove;
        _positionMove = positionMove;
        _positionSpawn = positionSpawn;

        ResetTransform();
    }

    public void Activate(int score)
    {
        _textScore.text = score.ToString();
        _particleShow.Play();

        transform.DOScale(_maxSize, _durationChangeScale).OnComplete(() =>
        {
            transform.DOMove(_positionMove, _durationMoveStar);
            transform.DOScale(0, _durationMoveStar).OnComplete(() =>
            {
                EndedAnimationGetScore?.Invoke();

                ResetTransform();
            });
        });
    }

    private void ResetTransform()
    {
        gameObject.SetActive(false);
        transform.localScale = Vector2.zero;
        transform.position = _positionSpawn;
    }
}