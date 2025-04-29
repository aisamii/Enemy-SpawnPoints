using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private Transform _target;

    public void Initialize(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        Vector3 direction = (_target.position - transform.position).normalized;

        transform.Translate(direction * _speed * Time.deltaTime);
    }
}
