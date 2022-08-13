using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrulPointManager : MonoBehaviour
{
    [SerializeField] private List<Transform> _patrolPoints;
    private List<Transform> _passedPoints = new List<Transform>();
    private Transform _currentPatrolPoint;

    private void ResetPatrulPoint()
    {
        foreach (Transform points in _passedPoints)
        {
            _patrolPoints.Add(points);
        }

        _passedPoints.Clear();
    }

    public void ChangeCurrentPatrolPoint()
    {
        if (_patrolPoints.Count == 0)
        {
            ResetPatrulPoint();
        }

        int randomSport = Random.Range(0, _patrolPoints.Count);
        _currentPatrolPoint = _patrolPoints[randomSport];
        _passedPoints.Add(_currentPatrolPoint);
        _patrolPoints.Remove(_currentPatrolPoint);

    }

    public Vector3 GetPositionCurrentPatrolPoint()
    {
        return _currentPatrolPoint.position;
    }
}
