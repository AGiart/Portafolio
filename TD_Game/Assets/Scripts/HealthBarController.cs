using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{

    [SerializeField]
    Image healthBar;

    [SerializeField]
    Gradient _healthGradient;

    [SerializeField]
    float maxHealth = 100.0F;

    float _currentHealth;

    private void Awake()
    {
        _currentHealth = maxHealth;
    }
    
    public void UpdateHealth(float amont)
    {
        _currentHealth += amont;
        _currentHealth = Mathf.Clamp(_currentHealth, 0.0F, maxHealth);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float fillAmont = _currentHealth / maxHealth;
        Color fillColor= _healthGradient.Evaluate(fillAmont);
        healthBar.fillAmount = fillAmont;
        healthBar.color = fillColor;

    }

}
