using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    [SerializeField] private Gun[] _guns;
    [SerializeField] private int _currentIndexOfGun;

    private void Start()
    {
        TakeGunByIndex(_currentIndexOfGun);
    }

    public void TakeGunByIndex(int gunIndex)
    {
        _currentIndexOfGun = gunIndex;
        for (int i = 0; i < _guns.Length; i++)
        {
            if (i == gunIndex)
            {
                _guns[i].Activate();
            }
            else
            {
                _guns[i].Deactivate();
            }
        }
    }

    public void AddBullets(int gunIndex, int bulletCount)
    {
        _guns[gunIndex].AddBullets(bulletCount);
    }
}