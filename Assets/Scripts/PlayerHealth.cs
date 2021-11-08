using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health = 3;
    [SerializeField] private int _maxHealth = 5;
    [SerializeField] private AudioSource _iGotHeal;
    [SerializeField] private HealthUi _healthUi;

    private bool _invincible = false;
    private bool _godMode = false;

    public UnityEvent IAmHit;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1) && !_godMode)
        {
            Invoke("AdminGodModeActivator", 0.001f);
        }

        if (Input.GetKeyDown(KeyCode.F1) && _godMode)
        {
            Invoke("AdminGodModeDisabler", 0.001f);
        }
    }

    private void Awake()
    {
        _healthUi.Setup(_maxHealth);
        _healthUi.DisplayHealth(_health);
    }
    
    public void TakeDamage(int damageValue)
    {
        if (!_invincible)
        {
            _health -= damageValue;
            IAmHit?.Invoke();
            if (_health <= 0)
            {
                _health = 0;
                if (!_godMode)
                {
                    Die();   
                }
            }

            _healthUi.DisplayHealth(_health);
            _invincible = true;
            Invoke("StopBeingAGod", 1);
        }
    }

    private void StopBeingAGod()
    {
        _invincible = false;
    }

    private void AdminGodModeActivator()
    {
        _godMode = true;
    }

    private void AdminGodModeDisabler()
    {
        _godMode = false;
    }

    public void AddHealth(int healthValue)
    {
        _health += healthValue;
        _iGotHeal.Play();
        _healthUi.DisplayHealth(_health);
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
