using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthUI : BaseUIBehaviour
{
    [SerializeField] private PlayerHealth _playerHeath;
    [SerializeField] private TextMeshProUGUI _healthText;

    private void Start()
    {
        _playerHeath.OnHealthChanged += SetHealth;
    }

    public void SetHealth(float currnet, float max)
    {
        _healthText.text = currnet.ToString();
    }
}
