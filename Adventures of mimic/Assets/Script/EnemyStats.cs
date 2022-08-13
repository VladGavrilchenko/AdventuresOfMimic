using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyStats : CharacterStats
{
    private TextMeshPro _textMeshProUGUI;

    private void Awake()
    {
        _textMeshProUGUI = GetComponentInChildren<TextMeshPro>();
    }

    public override void UpdateUI()
    {
        _textMeshProUGUI.SetText(GetCurrentHitPoint().ToString());
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
