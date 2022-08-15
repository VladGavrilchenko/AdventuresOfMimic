using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class CharacterStats : MonoBehaviour
{
    [SerializeField] private int _maxHitPoint = 100;
    [SerializeField] private int _damage = 10;
    [SerializeField] public int _armor = 0;
    private int _currentHitPoint;

    private void Start()
    {
        _currentHitPoint = _maxHitPoint;
        UpdateUI();
    }

    public virtual void TakeDamage(int damage)
    {
        damage -= _armor;
        damage = Mathf.Clamp(damage, 0, _maxHitPoint);
        _currentHitPoint -= damage;

        if (_currentHitPoint <= 0)
        {
            Die();
        }

        UpdateUI();
    }

    public virtual void UpdateUI()
    {

    }

    public virtual void Die()
    {

    }

    public int GetMaxHitPoint()
    {
        return _maxHitPoint;
    }

    public int GetDamage()
    {
        return _damage;
    }

    public int GetCurrentHitPoint()
    {
        return _currentHitPoint;
    }

    public int GetArmor()
    {
        return _armor;
    }

    public void SetArrmor(int newArrmor)
    {
        _armor = newArrmor;
    }

    public void SetDamage(int newDamage)
    {
        _damage = newDamage;
    }

    public void SetCurrentHitPoint(int newCurrentHitPoint)
    {
        _currentHitPoint = newCurrentHitPoint;
    }
}
