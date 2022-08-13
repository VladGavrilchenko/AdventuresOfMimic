using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusstItem : MonoBehaviour
{
    [SerializeField] private int _addHitPoint;
    [SerializeField] private int _addDamage;
    [SerializeField] private int _addArmor;

    public int GetAddDamage()
    {
        return _addDamage;
    }

    public int GetAddArmor()
    {
        return _addArmor;
    }

    public int GetAddHitPoint()
    {
        return _addHitPoint;
    }
}
