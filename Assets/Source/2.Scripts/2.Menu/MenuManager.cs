using UnityEngine;
using UnityEngine.Events;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private MenuManagerUI _menuManagerUI;
    [SerializeField] private MenuSpawnerSlimes _menuSpawnerSlimes;

    private InfoMenu _infoMenu;

    public event UnityAction TouchedPlayGame;

    private void OnEnable()
    {
        _menuManagerUI.ClickedButtonPlayGame += OnClickedButtonPlayGame;
    }

    private void OnDisable()
    {
        _menuManagerUI.ClickedButtonPlayGame -= OnClickedButtonPlayGame;
    }

    public void Initialize(InfoMenu infoMenu)
    {
        _infoMenu = infoMenu;
        _menuSpawnerSlimes.FillSlimesSpawn(_infoMenu.SizeAreaSpawnSlimes);

        ActivateMenu(0);
    }

    public void ActivateMenu(int maxScore)
    {
        _menuManagerUI.ShowMenu(true);
        _menuManagerUI.ChangeMaxScore(maxScore);
        _menuSpawnerSlimes.ActivateSpawn(true);
    }

    private void OnClickedButtonPlayGame()
    {
        _menuManagerUI.ShowMenu(false);
        _menuSpawnerSlimes.ActivateSpawn(false);

        TouchedPlayGame?.Invoke();
    }
}