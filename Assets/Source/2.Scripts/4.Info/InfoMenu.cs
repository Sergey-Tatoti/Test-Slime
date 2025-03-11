using UnityEngine;

[CreateAssetMenu(fileName = "InfoMenu", menuName = "Create/new InfoMenu", order = 51)]

public class InfoMenu : ScriptableObject
{
    [Header("��������� �������� ����")]
    [Tooltip("����������������� ������� ������� Loading")][SerializeField] private float _durationRotateLoading;
    [Tooltip("����� �������� ����� �������")][SerializeField] private float _timeShowerEndLoading;

    [Header("��������� ������ �������")]
    [Tooltip("������ ������� ������ �������")][SerializeField] private Vector2 _sizeAreaSpawnSlimes;

    public float TimeShowerEndLoading => _timeShowerEndLoading;
    public float DurationRotateLoading => _durationRotateLoading;
    public Vector2 SizeAreaSpawnSlimes => _sizeAreaSpawnSlimes;
}