using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] private FlaskController _flaskController;
    [SerializeField] private Pendulum _pendulum;
    [SerializeField] private StarPoint _starPoint;
    [SerializeField] private AreaDestroySlimes _areaDestroySlimes;
    [SerializeField] private AreaStuckSlimes _areaStuckSlimes;
    [SerializeField] private GameSpawnerSlimes _spawnerSlimes;
    [SerializeField] private GameManagerUI _gameManagerUI;

    private InfoGame _infoGame;
    private int _maxScore;
    private int _score;
    private bool _canUseAction = true;

    public int MaxScore => _maxScore;

    public event UnityAction TouchedReturnMenu;

    #region ----- Initialize ------

    public void Initialize(InfoGame infoGame)
    {
        _infoGame = infoGame;
        _pendulum.Initilialize(_infoGame.SpeedPendulum, _infoGame.LeftAnglePendulum, _infoGame.RightAnglePendulum, _infoGame.ModifierImpulsePandulum);
        _flaskController.Initialize(_infoGame.CountActiveFlask);
        _starPoint.Initialize(_infoGame.MaxSizeStar, _infoGame.DurationChangeScaleStar, _infoGame.DurationMoveStar,
                              _infoGame.GetPositionMoveStar(), _infoGame.GetPositionSpawnStar());
    }

    private void OnEnable()
    {
        _gameManagerUI.ClickedButtonBackMenu += OnClickedButtonBackMenu;
        _gameManagerUI.ClickedButtonRestartGame += ClickedButtonRestartGame;
        _areaDestroySlimes.DeactivatedSlime += OnDeactivatedSlime;
        _areaStuckSlimes.StuckedSlime += OnStuckedSlime;
        _starPoint.EndedAnimationGetScore += OnEndedAnimationGetScore;
        _flaskController.TakedSlimeOnFlask += OnTakedSlimeOnFlask;
        _flaskController.FilledFlask += OnFilledFlask;
        _flaskController.CleanedFlask += OnCleanedFlask;
        _flaskController.ClosedAllFlasks += OnClosedAllFlasks;
        _flaskController.PreparedFlasks += OnPreparedFlasks;
    }

    private void OnDisable()
    {
        _gameManagerUI.ClickedButtonBackMenu -= OnClickedButtonBackMenu;
        _gameManagerUI.ClickedButtonRestartGame -= ClickedButtonRestartGame;
        _areaDestroySlimes.DeactivatedSlime -= OnDeactivatedSlime;
        _areaStuckSlimes.StuckedSlime -= OnStuckedSlime;
        _starPoint.EndedAnimationGetScore -= OnEndedAnimationGetScore;
        _flaskController.TakedSlimeOnFlask -= OnTakedSlimeOnFlask;
        _flaskController.FilledFlask -= OnFilledFlask;
        _flaskController.CleanedFlask -= OnCleanedFlask;
        _flaskController.ClosedAllFlasks -= OnClosedAllFlasks;
        _flaskController.PreparedFlasks -= OnPreparedFlasks;
    }

    #endregion

    #region ----- States Game -----

    public void ActivateGame()
    {
        _gameManagerUI.ShowGameMenu(true);
        _gameManagerUI.ChangeScore(_score, _maxScore);
        _pendulum.Activate(_spawnerSlimes.GetRandomSlime());
    }

    public void UseActions()
    {
        if (_canUseAction)
            _pendulum.TryDetachSlime();
    }

    private void RestartGame()
    {
        _score = 0;

        _flaskController.ResetFlasks();
        _pendulum.Deactivate();
        _spawnerSlimes.ReturnAllSlimes();
        _gameManagerUI.ShowEndMenu(false);
    }

    #endregion

    #region ----- Actions Game -----

    private void ClickedButtonRestartGame() { RestartGame(); ActivateGame(); }

    private void OnEndedAnimationGetScore() => _gameManagerUI.ChangeScore(_score, _maxScore);

    private void OnDeactivatedSlime(Slime slime) => _pendulum.Activate(_spawnerSlimes.LastSlime);

    private void OnClosedAllFlasks() => _gameManagerUI.ShowEndMenu(true);

    private void OnTakedSlimeOnFlask() => _pendulum.Activate(_spawnerSlimes.GetRandomSlime());

    private void OnCleanedFlask(List<Slime> slimes) => _spawnerSlimes.ReturnSlimes(slimes);

    private void OnStuckedSlime() => _pendulum.Activate(_spawnerSlimes.LastSlime);

    private void OnPreparedFlasks()
    {
        _canUseAction = true;
        _pendulum.Activate(_spawnerSlimes.GetRandomSlime());
        _areaStuckSlimes.Activate(true);
    }

    private void OnFilledFlask(int score)
    {
        _canUseAction = false;
        _score += score;
        _maxScore = _maxScore > _score ? _maxScore : _score;

        _starPoint.gameObject.SetActive(true);
        _starPoint.Activate(score);
        _areaStuckSlimes.Activate(false);
    }

    private void OnClickedButtonBackMenu()
    {
        RestartGame();
        _gameManagerUI.ShowGameMenu(false);

        TouchedReturnMenu?.Invoke();
    }

    #endregion
}