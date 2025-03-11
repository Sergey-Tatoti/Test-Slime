using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Flask : MonoBehaviour
{
    private const string KeyAnimationClose = "isClose";
    private const string KeyAnimationShake = "Shake";
    private const int CountFullSlimes = 3;

    [SerializeField] private SpriteRenderer _imageFull;
    [SerializeField] private SpriteRenderer _imageShake;
    [SerializeField] private Transform _conteinerSlimes;

    private Animator _animator;
    private List<Slime> _takedSlimes = new List<Slime>();

    public event UnityAction TakedSlime;
    public event UnityAction<List<Slime>> CleanedSlimes;
    public event UnityAction Closed;
    public event UnityAction Prepared;
    public event UnityAction<Flask, Slime.Type> FilledSlimes;

    public void Initialize() => _animator = GetComponent<Animator>();

    public void UseShake(Sprite spriteFull, Sprite spriteShake)
    {
        _imageFull.sprite = spriteFull;
        _imageShake.sprite = spriteShake;

        _animator.SetTrigger(KeyAnimationShake);
    }

    public void ResetSlimes()
    {
        CleanedSlimes?.Invoke(_takedSlimes);

        _takedSlimes.Clear();
        _animator.SetBool(KeyAnimationClose, false);
    }

    public void EndedPrepared() => Prepared?.Invoke(); //Используется в аниматоре

    #region ----- Action Take Slime -----

    private void TakeSlime(Slime slime)
    {
        slime.transform.SetParent(_conteinerSlimes);
        _takedSlimes.Add(slime);

        if (_takedSlimes.Count != CountFullSlimes)
            TakedSlime?.Invoke();
        else
            ActionAfterFilled();
    }

    private void ActionAfterFilled()
    {
        _animator.SetBool(KeyAnimationClose, true);

        if (CheckRightFilled() == true)
            FilledSlimes(this, _takedSlimes[0].TypeSlime);
        else
        {
            CloseFlask();
            Prepared?.Invoke();
        }
    }

    private void CloseFlask()
    {
        Closed.Invoke();
    }

    private bool CheckRightFilled()
    {
        for (int i = 0; i < _takedSlimes.Count; i++)
        {
            if (_takedSlimes[0].TypeSlime != _takedSlimes[i].TypeSlime)
                return false;
        }
        return true;
    }

    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Slime>(out Slime slime))
            TakeSlime(slime);
    }
}