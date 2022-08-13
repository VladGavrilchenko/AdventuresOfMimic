using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

interface IPlayerStats
{
    public void TakeDamage(int damage);
    public int GetDamage();
    public void BusstStats(BusstItem busstItem);
}

public class PlayerStats : CharacterStats, IPlayerStats
{
    [SerializeField] private TextMeshProUGUI _currentHpText;
    [SerializeField] private TextMeshProUGUI _armorText;
    [SerializeField] private TextMeshProUGUI _damageText;

    private void Start()
    {
        SetCurrentHitPoint(GetMaxHitPoint());
        UpdateUI();
    }

    public override void UpdateUI()
    {
        _currentHpText.text = GetCurrentHitPoint().ToString();
        _armorText.text = GetArmor().ToString();
        _damageText.text = GetDamage().ToString();
    }

    public override void Die()
    {
        GetComponentInChildren<Animator>().SetTrigger("Die");
        SceneManager.SetActiveScene(SceneManager.GetActiveScene());
    }

    public void BusstStats(BusstItem busstItem)
    {

        if (IsAddingToHitPointMoreMaxHitPoint(busstItem.GetAddHitPoint()))
        {
            return;
        }

        AddToHitPoint(busstItem.GetAddHitPoint());
        AddToArmor(busstItem.GetAddArmor());
        AddToDamage(busstItem.GetAddDamage());
        UpdateUI();
    }

    private bool IsAddingToHitPointMoreMaxHitPoint(int addHitPoint)
    {
        int busstHitPoint = addHitPoint + GetCurrentHitPoint();

        if (busstHitPoint > GetMaxHitPoint())
        {
            return true;
        }

        return false;
    }

    private void AddToHitPoint(int addHitPoint)
    {
        addHitPoint += GetCurrentHitPoint();
        SetCurrentHitPoint(addHitPoint);
    }

    private void AddToArmor(int addArmor)
    {
        addArmor += GetArmor();
        SetArrmor(addArmor);
    }

    private void AddToDamage(int addDamage)
    {
        addDamage += GetDamage();
        SetDamage(addDamage);
    }

}
