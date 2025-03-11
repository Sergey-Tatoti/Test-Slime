using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuManagerUI : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private TMP_Text _textMaxScore;
    [SerializeField] private Button _buttonPlayGame;

    public event UnityAction ClickedButtonPlayGame;

    private void OnEnable()
    {
        _buttonPlayGame.onClick.AddListener(() => ClickedButtonPlayGame?.Invoke());
    }

    private void OnDisable()
    {
        _buttonPlayGame.onClick.RemoveListener(() => ClickedButtonPlayGame?.Invoke());
    }

    public void ShowMenu(bool isShow) => _menu.SetActive(isShow);

    public void ChangeMaxScore(int maxScore) => _textMaxScore.text = maxScore.ToString();
}