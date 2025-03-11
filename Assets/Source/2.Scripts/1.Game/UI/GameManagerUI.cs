using UnityEngine;
using UnityEngine.Events;

public class GameManagerUI : MonoBehaviour
{
    [SerializeField] private GameObject _panelGameMenu;
    [SerializeField] private GameObject _panelEndMenu;
    [Space]
    [SerializeField] private EndMenuUI _endMenuUI;
    [SerializeField] private GameUI _gameUI;

    public event UnityAction ClickedButtonBackMenu;
    public event UnityAction ClickedButtonRestartGame;

    private void OnEnable()
    {
        _endMenuUI.ClickedButtonBackMenu += OnClickedButtonBackMenu;
        _endMenuUI.ClickedButtonRestartGame += OnClickedButtonRestartMenu;
        _gameUI.ClickedButtonBackMenu += OnClickedButtonBackMenu;
        _gameUI.ClickedButtonRestartGame += OnClickedButtonRestartMenu;
    }

    private void OnDisable()
    {
        _endMenuUI.ClickedButtonBackMenu -= OnClickedButtonBackMenu;
        _endMenuUI.ClickedButtonRestartGame -= OnClickedButtonRestartMenu;
        _gameUI.ClickedButtonBackMenu -= OnClickedButtonBackMenu;
        _gameUI.ClickedButtonRestartGame -= OnClickedButtonRestartMenu;
    }

    public void ShowGameMenu(bool isShow) => _panelGameMenu.gameObject.SetActive(isShow);

    public void ShowEndMenu(bool isShow) => _panelEndMenu.gameObject.SetActive(isShow);

    public void ChangeScore(int score, int maxScore)
    {
        _gameUI.ChangeScore(score);
        _endMenuUI.ChangeScores(score, maxScore);
    }

    private void OnClickedButtonBackMenu() => ClickedButtonBackMenu?.Invoke();

    private void OnClickedButtonRestartMenu() => ClickedButtonRestartGame?.Invoke();
}