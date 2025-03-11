using UnityEngine;

[CreateAssetMenu(fileName = "InfoMenu", menuName = "Create/new InfoMenu", order = 51)]

public class InfoMenu : ScriptableObject
{
    [Header("Настройка перехода сцен")]
    [Tooltip("Продолжительность полного оборота Loading")][SerializeField] private float _durationRotateLoading;
    [Tooltip("Время перехода между сценами")][SerializeField] private float _timeShowerEndLoading;

    [Header("Настройка Спавна слаймов")]
    [Tooltip("Размер области спавна слаймов")][SerializeField] private Vector2 _sizeAreaSpawnSlimes;

    public float TimeShowerEndLoading => _timeShowerEndLoading;
    public float DurationRotateLoading => _durationRotateLoading;
    public Vector2 SizeAreaSpawnSlimes => _sizeAreaSpawnSlimes;
}