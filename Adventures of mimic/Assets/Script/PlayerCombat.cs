using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private float _attackRange = 1f;
    [SerializeField] private float _attackRate = 2f;
    [SerializeField] private LayerMask _enemyLayers;
    [SerializeField] private LayerMask _barrierLayers;
    [SerializeField] private Transform _attackPoint;
    private float _nextAttackTime = 0f;
    private IPlayerStats _playerStats;
    private Animator _animator;

    void Start()
    {
        _playerStats = GetComponent<PlayerStats>().GetComponent<IPlayerStats>();
        _animator = GetComponentInChildren<Animator>();
    }

    public void Attack()
    {
        if (Time.time >= _nextAttackTime)
        {

            Collider[] barriers = Physics.OverlapSphere(_attackPoint.position, _attackRange, _barrierLayers);

            if (barriers.Length != 0)
            {
                return;
            }

            _animator.SetTrigger("Attack");

            Collider[] hitEnemis = Physics.OverlapSphere(_attackPoint.position, _attackRange, _enemyLayers);

            foreach (Collider enemy in hitEnemis)
            {
                enemy.GetComponent<CharacterStats>().TakeDamage(_playerStats.GetDamage());
            }

            _nextAttackTime = Time.time + 1f / _attackRate;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }

}
