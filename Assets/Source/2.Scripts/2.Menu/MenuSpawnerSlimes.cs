using System.Collections.Generic;
using UnityEngine;

public class MenuSpawnerSlimes : MonoBehaviour
{
    [SerializeField] private AreaDestroySlimes _areaDestroy;
    [SerializeField] private AreaSpawnSlimes _areaSpawn;
    [Header("Контейнер откуда берутся все слаймы для спавна")]
    [SerializeField] private Transform _conteinerSpawnSlimes;

    private List<Slime> _slimesSpawn = new List<Slime>();

    private void OnEnable() => _areaDestroy.DeactivatedSlime += OnDeactivatedSlime;

    private void OnDisable() => _areaDestroy.DeactivatedSlime -= OnDeactivatedSlime;

    public void FillSlimesSpawn(Vector3 sizeAreaSpawn)
    {
        _areaSpawn.SetSizeAreaSpawn(sizeAreaSpawn);

        for (int i = 0; i < _conteinerSpawnSlimes.childCount; i++)
        {
            if (_conteinerSpawnSlimes.GetChild(i).TryGetComponent<Slime>(out Slime slime))
            {
                slime.Initialize();
                _slimesSpawn.Add(slime);
            }
        }
    }

    public void ActivateSpawn(bool isActivate)
    {
        for (int i = 0; i < _slimesSpawn.Count; i++)
        {
            SpawnSlime(_slimesSpawn[i], isActivate);
        }
    }

    private void SpawnSlime(Slime slime, bool showSlime = true)
    {
        Vector2 randomPoint = GetRandomPointInSprite();

        slime.transform.position = randomPoint;
        slime.gameObject.SetActive(showSlime);
    }

    private Vector2 GetRandomPointInSprite()
    {
        float randomX = Random.Range(-_areaSpawn.SizeAreaSpawn.x / 2f, _areaSpawn.SizeAreaSpawn.x / 2f);
        float randomY = Random.Range(-_areaSpawn.SizeAreaSpawn.y / 2f, _areaSpawn.SizeAreaSpawn.y / 2f);

        Vector2 randomPoint = new Vector2(randomX, randomY) + (Vector2)_areaSpawn.transform.position;

        return randomPoint;
    }

    private void OnDeactivatedSlime(Slime slime)
    {
        slime.ResetChanges();

        SpawnSlime(slime);
    }
}