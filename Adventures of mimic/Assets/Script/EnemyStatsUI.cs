using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyStatsUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _hitPointText;
    [SerializeField] private Image _imageProvoked;
    private void Start()
    {
        SetEnableImageProvoked(false);
        Enemy enemy = FindObjectOfType<Enemy>();
        enemy.OnIsProvoked.AddListener(SetEnableImageProvoked);
    }

    private void LateUpdate()
    {
        transform.LookAt(new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z));
    }

    public void HitPointUIUptade(int newHitPointText)
    {
        _hitPointText.text = newHitPointText.ToString();
    }

    private void SetEnableImageProvoked(bool isEnable)
    {
        _imageProvoked.enabled = isEnable;
    }
}
