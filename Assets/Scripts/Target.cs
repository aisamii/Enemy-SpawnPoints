using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    [SerializeField] private List<Transform> _wayPoints;

    private (Transform transform, int index) _targetWayPoint;
    private float _minDistanceToSwitchWayPoint = 0.05f;

    private void Start()
    {
        _targetWayPoint.index = 0;
        _targetWayPoint.transform = _wayPoints[0];
    }

    private void Update()
    {
        MoveToTargetWayPoint();

        if ((transform.position - _targetWayPoint.transform.position).magnitude < _minDistanceToSwitchWayPoint)
            SwitchTargetWayPoint();
    }

    private void MoveToTargetWayPoint()
    {
        Vector3 direction = (_targetWayPoint.transform.position - transform.position).normalized;

        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void SwitchTargetWayPoint()
    {
        if(_targetWayPoint.index + 1 == _wayPoints.Count)
            _targetWayPoint.index = 0;
        else
            _targetWayPoint.index++;

        _targetWayPoint.transform = _wayPoints[_targetWayPoint.index];
    }
}
