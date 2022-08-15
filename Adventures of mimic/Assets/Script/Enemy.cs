using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _chaseRange;
    [SerializeField] private float _turnSpeed;
    private double _distanceToPlayer;
    private NavMeshAgent _agent;
    private Transform _playerTransform;
    private PatrulPointManager _patrulPointManager;
    private EnemyFight _enemyFight;
    private bool _isProvoked;
    private Animator _animator;

    public UnityEvent<bool> OnIsProvoked;

    private void Start()
    {
        _enemyFight = GetComponent<EnemyFight>();
        _playerTransform = FindObjectOfType<PlayerStats>().transform;
        _agent = GetComponent<NavMeshAgent>();
        _patrulPointManager = GetComponent<PatrulPointManager>();
        _patrulPointManager.ChangeCurrentPatrolPoint();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        _distanceToPlayer = Vector3.Distance(_playerTransform.position, transform.position);

        if (_distanceToPlayer <= _chaseRange || _isProvoked)
        {
            if (_distanceToPlayer <= _agent.stoppingDistance)
            {
                _enemyFight.AttackPlayer();
            }
            else
            {
                
                MoveToPlayer();
            }
            _isProvoked = true;
            OnIsProvoked.Invoke(_isProvoked);
        }
        else
        {
            Patrul();
        }
    }

    private void MoveToPlayer()
    {
        _animator.SetBool("Move", true);
        _agent.SetDestination(_playerTransform.position);
        FaceTarget(_playerTransform.position);
    }

    private void Patrul()
    {
        _animator.SetBool("Move", true);
        _agent.SetDestination(_patrulPointManager.GetPositionCurrentPatrolPoint());

        if (Vector3.Distance(transform.position, _patrulPointManager.GetPositionCurrentPatrolPoint()) < _agent.stoppingDistance)
        {
            _patrulPointManager.ChangeCurrentPatrolPoint();
            FaceTarget(_patrulPointManager.GetPositionCurrentPatrolPoint());
        }
    }

    private void FaceTarget(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _chaseRange);
    }

}
