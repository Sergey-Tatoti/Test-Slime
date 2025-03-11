using UnityEngine;

[CreateAssetMenu(fileName = "InfoGame", menuName = "Create/new InfoGame", order = 51)]

public class InfoGame : ScriptableObject
{
    private const float MinValueAnglePendulum = 0.2f;
    private const float MaxValueAnglePendulum = 0.99f;

    [Header("��������� ��������")]
    [Tooltip("�������� �������� ��������")][SerializeField] private float _speedPendulum;
    [Tooltip("���������� ��� �������� �������� ��� ���������� ������")][SerializeField] private float _modifierImpulsePandulum;
    [Tooltip("���� ����� ����")][Range(MinValueAnglePendulum, MaxValueAnglePendulum)][SerializeField] private float _leftAnglePendulum;
    [Tooltip("���� ������ ����")][Range(MinValueAnglePendulum, MaxValueAnglePendulum)][SerializeField] private float _rightAnglePendulum;

    [Header("��������� ������ � ��������")]
    [Tooltip("������ ������ ��� ���������")][SerializeField] private float _maxSizeStar;
    [Tooltip("����������������� ��������� ������� ��� ���������")][SerializeField] private float _durationChangeScaleStar;
    [Tooltip("����������������� �������� ������")][SerializeField] private float _durationMoveStar;
    [Tooltip("�������� ������� �������� ������ �� ������ ������ ������")][SerializeField] private Vector2 _offsetPositionMoveStar;
    [Tooltip("�������� ������� ������ ������ �� ������ ������")][SerializeField] private Vector2 _offsetPositionSpawnStar;

    [Header("��������� ��������")]
    [Tooltip("���-�� �������� ��������")][SerializeField] private int _countActiveFlask;

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