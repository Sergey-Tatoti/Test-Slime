using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Vector2 _endScale;
    [SerializeField] private float _durationChangeScale = 0.5f;

    private Sequence _sequence;
    private Vector2 _startScale = Vector2.one;

    private void Awake() => _startScale = transform.localScale;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_sequence != null)
            _sequence.Kill();

        _sequence = DOTween.Sequence().Append(transform.DOScale(_startScale, _durationChangeScale));
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_sequence != null)
            _sequence.Kill();

        _sequence = DOTween.Sequence().Append(transform.DOScale(_endScale, _durationChangeScale));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_sequence != null)
            _sequence.Kill();

        _sequence = DOTween.Sequence().Append(transform.DOScale(_startScale, _durationChangeScale));
    }
}