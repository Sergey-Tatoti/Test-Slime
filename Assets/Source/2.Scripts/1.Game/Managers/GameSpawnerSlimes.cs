using System.Collections.Generic;
using UnityEngine;

public class GameSpawnerSlimes : MonoBehaviour
{
    [SerializeField] private Transform _conteinerSlimes;
    [SerializeField] private List<Slime> _prefabsSlimes;

    private List<Slime> _slimes = new List<Slime>();
    private Slime _lastSlime;

    public Slime LastSlime => _lastSlime;

    public Slime GetRandomSlime()
    {
        int randomIndex = Random.Range(0, _prefabsSlimes.Count);

        _lastSlime = GetFreeSlime(_prefabsSlimes[randomIndex]);

        if (_lastSlime == null)
            CreateSlime(_prefabsSlimes[randomIndex]);

        return _lastSlime;
    }

    public void ReturnAllSlimes() => ReturnSlimesConteiner(_slimes);

    public void ReturnSlimes(List<Slime> slimes) => ReturnSlimesConteiner(slimes);

    private void ReturnSlimesConteiner(List<Slime> slimes)
    {
        for (int i = 0; i < slimes.Count; i++)
        {
            slimes[i].gameObject.SetActive(false);
            slimes[i].transform.SetParent(_conteinerSlimes);
        }
    }

    private void CreateSlime(Slime prefabSlime)
    {
        Slime slime = Instantiate(prefabSlime, _conteinerSlimes);

        slime.Initialize();

        _slimes.Add(slime);
        _lastSlime = slime;
    }

    private Slime GetFreeSlime(Slime slime)
    {
        for (int i = 0; i < _slimes.Count; i++)
        {
            if (_slimes[i].TypeSlime == slime.TypeSlime && !_slimes[i].gameObject.activeSelf)
                return _slimes[i];
        }
        return null;
    }
}