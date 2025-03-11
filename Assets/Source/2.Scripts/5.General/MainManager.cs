using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] private InfoMenu _infoMenu;
    [SerializeField] private InfoGame _infoGame;
    [SerializeField] private MenuManager _menuManager;
    [SerializeField] private GamePlayManager _gamePlayManager;
    [SerializeField] private SceneTransition _sceneTransition;

    private bool _isGame;

    private void OnEnable()
    {
        _menuManager.TouchedPlayGame += OnTouchedPlayGame;
        _gamePlayManager.TouchedReturnMenu += OnTouchedReturnMenu;
    }

    private void OnDisable()
    {
        _menuManager.TouchedPlayGame -= OnTouchedPlayGame;
        _gamePlayManager.TouchedReturnMenu -= OnTouchedReturnMenu;
    }

    private void Awake()
    {
        _sceneTransition.Initialize(_infoMenu.DurationRotateLoading, _infoMenu.TimeShowerEndLoading);
        _menuManager.Initialize(_infoMenu);
        _gamePlayManager.Initialize(_infoGame);
    }

    private void Update()
    {
        if (_isGame)
            _gamePlayManager.UseActions();
    }

    private void OnTouchedReturnMenu()
    {
        _sceneTransition.ShowLoading();
        _menuManager.ActivateMenu(_gamePlayManager.MaxScore);
        _isGame = false;
    }

    private void OnTouchedPlayGame()
    {
        _sceneTransition.ShowLoading();
        _gamePlayManager.ActivateGame();
        _isGame = true;
    }
}