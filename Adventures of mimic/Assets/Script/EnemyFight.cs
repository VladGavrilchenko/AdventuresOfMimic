using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFight : MonoBehaviour
{
    [SerializeField] private float _attackRate = 2f;
    private CharacterStats _characterStats;
    private float _nextAttackTime;
    private IPlayerStats _playerStats;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _characterStats = GetComponent<EnemyStats>();
        _playerStats = FindObjectOfType<PlayerStats>().GetComponent<IPlayerStats>();
    }
    public void AttackPlayer()
    {
        if (Time.time >= _nextAttackTime)
        {
            _animator.SetTrigger("Attack");
            _playerStats.TakeDamage(_characterStats.GetDamage());
            _nextAttackTime = Time.time + 1f / _attackRate;
        }
    }
   
}
