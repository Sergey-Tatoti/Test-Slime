using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlaskController : MonoBehaviour
{
    [SerializeField] private InfoFlask _infoFlask;
    [SerializeField] private List<Flask> _flasks;

    private int _countClosedFlasks;
    private List<Flask> _activeFlasks = new List<Flask>();

    public event UnityAction TakedSlimeOnFlask;
    public event UnityAction<int> FilledFlask;
    public event UnityAction ClosedAllFlasks;
    public event UnityAction PreparedFlasks;
    public event UnityAction<List<Slime>> CleanedFlask;

    public void Initialize(int countActiveFlasks)
    {
        countActiveFlasks = Mathf.Clamp(countActiveFlasks, 1, _flasks.Count);

        for (int i = 0; i < countActiveFlasks; i++)
        {
            _activeFlasks.Add(_flasks[i]);
            _activeFlasks[i].Initialize();
            _activeFlasks[i].gameObject.SetActive(true);

            _activeFlasks[i].TakedSlime += OnTakedSlime;
            _activeFlasks[i].FilledSlimes += OnFilledSlimes;
            _activeFlasks[i].CleanedSlimes += OnCleanedSlimes;
            _activeFlasks[i].Closed += OnClosed;
            _activeFlasks[i].Prepared += OnPrepared;
        }
    }

    public void ResetFlasks()
    {
        _countClosedFlasks = 0;

        for (int i = 0; i < _activeFlasks.Count; i++)
        {
            _activeFlasks[i].ResetSlimes();
        }
    }

    #region ----- Actions Status Flasks -----

    private void OnTakedSlime() => TakedSlimeOnFlask?.Invoke();

    private void OnPrepared() => PreparedFlasks?.Invoke();

    private void OnCleanedSlimes(List<Slime> slimes) => CleanedFlask?.Invoke(slimes);

    private void OnFilledSlimes(Flask flask, Slime.Type typeSlime)
    {
        FilledFlask?.Invoke(_infoFlask.GetCountScore(typeSlime));

        flask.UseShake(_infoFlask.GetSpriteFull(typeSlime), _infoFlask.GetSpriteShake(typeSlime));
    }

    private void OnClosed()
    {
        _countClosedFlasks++;

        if (_countClosedFlasks >= _activeFlasks.Count)
            ClosedAllFlasks?.Invoke();
    }

    #endregion

}