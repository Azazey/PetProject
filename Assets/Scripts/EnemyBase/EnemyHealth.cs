using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health = 2;
    [SerializeField] private AudioSource _deathSound;
    [SerializeField] private GameObject _effectPrefab;

    private const int _soundLiveTime = 3;

    public UnityEvent Damaged;

    public int Health => _health;

    public void TakeDamage(int damageValue)
    {
        Damaged?.Invoke();
        _health -= damageValue;
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        DeathSoundPlay();
        EffectsAfterDeath();
        Destroy(gameObject);
    }

    private void DeathSoundPlay()
    {
        if (_deathSound != null)
        {
            _deathSound.Play();
            _deathSound.gameObject.transform.parent = null;
            Destroy(_deathSound.gameObject, _soundLiveTime);
        }
    }

    private void EffectsAfterDeath()
    {
        if (_effectPrefab != null)
        {
            Instantiate(_effectPrefab, transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
        }
    }
}