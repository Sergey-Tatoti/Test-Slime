using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InfoFlask", menuName = "Create/new InfoFlask", order = 51)]

public class InfoFlask : ScriptableObject
{
    [Header("Установка значений в зависимотси от типа Слайма")]
    [SerializeField] private List<Slime.Type> _typesSlimes;
    [Tooltip("Очки при заполненном Флаконе")][SerializeField] private List<int> _countsScore;
    [Tooltip("Спрайт полного флакона")][SerializeField] private List<Sprite> _spritesFull;
    [Tooltip("Спрайт шейка")][SerializeField] private List<Sprite> _spritesShake;

    public int GetCountScore(Slime.Type typeSlime) => _countsScore[GetIndexByTypeSlime(typeSlime)];

    public Sprite GetSpriteFull(Slime.Type typeSlime) => _spritesFull[GetIndexByTypeSlime(typeSlime)];

    public Sprite GetSpriteShake(Slime.Type typeSlime) => _spritesShake[GetIndexByTypeSlime(typeSlime)];

    private int GetIndexByTypeSlime(Slime.Type typeSlime)
    {
        for (int i = 0; i < _typesSlimes.Count; i++)
        {
            if (_typesSlimes[i] == typeSlime)
                return i;
        }
        return 0;
    }
}