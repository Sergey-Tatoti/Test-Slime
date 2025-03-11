using UnityEngine;

[CreateAssetMenu(fileName = "InfoGame", menuName = "Create/new InfoGame", order = 51)]

public class InfoGame : ScriptableObject
{
    private const float MinValueAnglePendulum = 0.2f;
    private const float MaxValueAnglePendulum = 0.99f;

    [Header("Настройки маятника")]
    [Tooltip("Скорость вращения маятника")][SerializeField] private float _speedPendulum;
    [Tooltip("Модификтор для уселения импульса при отпускании слайма")][SerializeField] private float _modifierImpulsePandulum;
    [Tooltip("Макс левый угол")][Range(MinValueAnglePendulum, MaxValueAnglePendulum)][SerializeField] private float _leftAnglePendulum;
    [Tooltip("Макс правый угол")][Range(MinValueAnglePendulum, MaxValueAnglePendulum)][SerializeField] private float _rightAnglePendulum;

    [Header("Настройки звезды с наградой")]
    [Tooltip("Размер звезды при появлении")][SerializeField] private float _maxSizeStar;
    [Tooltip("Продолжительность изменения размера при появлении")][SerializeField] private float _durationChangeScaleStar;
    [Tooltip("Продолжительность движения звезды")][SerializeField] private float _durationMoveStar;
    [Tooltip("Смещение позиции движения звезды от центра правой стенки")][SerializeField] private Vector2 _offsetPositionMoveStar;
    [Tooltip("Смещение позиции спавна звезды от центра экрана")][SerializeField] private Vector2 _offsetPositionSpawnStar;

    [Header("Настройка флаконов")]
    [Tooltip("Кол-во активных флаконов")][SerializeField] private int _countActiveFlask;

    public int CountActiveFlask => _countActiveFlask;
    public float SpeedPendulum => _speedPendulum;
    public float ModifierImpulsePandulum => _modifierImpulsePandulum;
    public float LeftAnglePendulum => _leftAnglePendulum;
    public float RightAnglePendulum => _rightAnglePendulum;
    public float MaxSizeStar => _maxSizeStar;
    public float DurationChangeScaleStar => _durationChangeScaleStar;
    public float DurationMoveStar => _durationMoveStar;

    public Vector2 GetPositionMoveStar()
    {
        Vector2 rightCenterScreenPoint = new Vector2(Screen.width, Screen.height / 2) + _offsetPositionMoveStar;

        return Camera.main.ScreenToWorldPoint(rightCenterScreenPoint);
    }

    public Vector2 GetPositionSpawnStar()
    {
        Vector2 centerScreenPoint = new Vector2(Screen.width / 2, Screen.height / 2) + _offsetPositionSpawnStar;

        return Camera.main.ScreenToWorldPoint(centerScreenPoint);
    }
}