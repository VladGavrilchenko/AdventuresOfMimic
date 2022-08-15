using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerEat : MonoBehaviour
{
    [SerializeField] private float _eatRange;
    [SerializeField] private LayerMask _barrierLayers;
    [SerializeField] private LayerMask _busstLayers;
    [SerializeField] private float _eatRate = 2f;
    [SerializeField] private Transform _eatPoint;

    private Animator _animator;
    private float _nextEatTime = 0f;
    private IPlayerStats _playerStats;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _playerStats = GetComponent<PlayerStats>().GetComponent<IPlayerStats>();
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_eatPoint.position, _eatRange);
    }
  

    private void OnEat()
    {

        if (Time.time >= _nextEatTime)
        {

            Collider[] barriers = Physics.OverlapSphere(_eatPoint.position, _eatRange, _barrierLayers);

            if (barriers.Length != 0)
            {
                return;
            }
            _animator.SetTrigger("Eat");

            Collider[] hitBusst = Physics.OverlapSphere(_eatPoint.position, _eatRange, _busstLayers);

            foreach (Collider busst in hitBusst)
            {
                var itemBusst = busst.GetComponent<BusstItem>();

                if (itemBusst != null)
                {
                    _playerStats.BusstStats(itemBusst);
                }
            }

            _nextEatTime = Time.time + 1f / _eatRate;

        }
    }
}
