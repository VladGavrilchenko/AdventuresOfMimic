using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyStats : CharacterStats
{
    private EnemyStatsUI _enemyStatsUI;
    private void Awake()
    {
        _enemyStatsUI = FindObjectOfType<EnemyStatsUI>();
    }

    public override void UpdateUI()
    {
        _enemyStatsUI.HitPointUIUptade(GetCurrentHitPoint());
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
