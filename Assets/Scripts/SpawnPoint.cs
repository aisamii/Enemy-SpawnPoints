using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [field: SerializeField] public Enemy EnemyPrefab {  get; private set; }
    [field: SerializeField] public Transform EnemyTarget {  get; private set; }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 0.3f);
    }
}
