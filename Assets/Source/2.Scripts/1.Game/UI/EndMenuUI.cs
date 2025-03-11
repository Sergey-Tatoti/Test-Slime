using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EndMenuUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _textScore;
    [SerializeField] private TMP_Text _textMaxScore;
    [SerializeField] private Button _buttonBackMenu;
    [SerializeField] private Button _buttonRestartGame;

    public event UnityAction ClickedButtonBackMenu;
    public event UnityAction ClickedButtonRestartGame;

    private void OnEnable()
    {
        _buttonBackMenu.onClick.AddListener(() => ClickedButtonBackMenu?.Invoke());
        _buttonRestartGame.onClick.AddListener(() => ClickedButtonRestartGame?.Invoke());
    }

    private void OnDisable()
    {
        _buttonBackMenu.onClick.RemoveListener(() => ClickedButtonBackMenu?.Invoke());
        _buttonRestartGame.onClick.AddListener(() => ClickedButtonRestartGame?.Invoke());
    }

    public void ChangeScores(int score, int maxScore)
    {
        _textScore.text = score.ToString();
        _textMaxScore.text = maxScore.ToString();
    }
}