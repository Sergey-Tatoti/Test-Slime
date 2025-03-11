using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Image _panelLoading;
    [SerializeField] private Image _imageLoading;

    private float _durationRotate;
    private float _timeShowerEnd;
    private Vector3 _rotationAxis = new Vector3(0, 0, 1);

    public void Initialize(float durationRotate, float timeShowerEnd)
    {
        _durationRotate = durationRotate;
        _timeShowerEnd = timeShowerEnd;
    }

    public void ShowLoading()
    {
        _panelLoading.gameObject.SetActive(true);

        RotateLoading();
        StartCoroutine(EndShowerLoading());
    }

    private void RotateLoading()
    {
        _imageLoading.transform.DORotate(_rotationAxis * 360, _durationRotate, RotateMode.LocalAxisAdd)
                 .SetEase(Ease.Linear)
                 .OnComplete(RotateLoading);
    }

    private IEnumerator EndShowerLoading()
    {
        yield return new WaitForSeconds(_timeShowerEnd);

        DOTween.Kill(this);

        _panelLoading.gameObject.SetActive(false);
    }
}