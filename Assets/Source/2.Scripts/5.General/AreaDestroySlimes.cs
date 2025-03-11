using UnityEngine;
using UnityEngine.Events;

public class AreaDestroySlimes : MonoBehaviour
{
    public event UnityAction<Slime> DeactivatedSlime;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Slime>(out Slime slime))
        {
            slime.gameObject.SetActive(false);
            DeactivatedSlime?.Invoke(slime);
        }
    }
}