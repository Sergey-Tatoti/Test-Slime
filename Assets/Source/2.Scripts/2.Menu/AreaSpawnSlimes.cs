using UnityEngine;

public class AreaSpawnSlimes : MonoBehaviour
{
    [SerializeField] private Vector2 _sizeAreaSpawn;

    public Vector2 SizeAreaSpawn => _sizeAreaSpawn;

    public void SetSizeAreaSpawn(Vector3 sizeAreaSpawn) => _sizeAreaSpawn = sizeAreaSpawn;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position, _sizeAreaSpawn);
    }
}