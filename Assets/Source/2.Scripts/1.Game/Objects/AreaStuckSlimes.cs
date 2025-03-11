using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AreaStuckSlimes : MonoBehaviour
{
    private float _timeOutStay = 3f;
    private Coroutine _coroutineStuckTime;

    public event UnityAction StuckedSlime;

    public void Activate(bool isActivate) => GetComponent<AreaStuckSlimes>().enabled = isActivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Slime>() && _coroutineStuckTime == null)
            _coroutineStuckTime = StartCoroutine(UseCheckStuckTime());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Slime>() && _coroutineStuckTime != null)
        {
            StopCoroutine(_coroutineStuckTime);
            _coroutineStuckTime = null;
        }
    }

    private IEnumerator UseCheckStuckTime()
    {
        float elipsedTime = 0;

        while (elipsedTime <= _timeOutStay)
        {
            elipsedTime += Time.deltaTime;

            yield return null;
        }

        if (elipsedTime >= _timeOutStay)
            StuckedSlime?.Invoke();
    }
}
