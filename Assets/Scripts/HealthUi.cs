using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUi : MonoBehaviour
{
    [SerializeField] private GameObject _healthIconPrefab;
    [SerializeField] List<GameObject> _healthIcons = new List<GameObject>();

    public void Setup(int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject newIcon = Instantiate(_healthIconPrefab, transform);
            _healthIcons.Add(newIcon);
        }
    }

    public void DisplayHealth(int health)
    {
        for (int i = 0; i < _healthIcons.Count; i++)
        {
            if (i < health)
            {
                _healthIcons[i].SetActive(true);
            }
            else
            {
                _healthIcons[i].SetActive(false);
            }
        }
    }
}