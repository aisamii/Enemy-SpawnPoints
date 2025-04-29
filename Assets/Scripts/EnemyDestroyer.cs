using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
            Destroy(enemy.gameObject);
    }
}
