using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ppsh : Gun
{
    [Header("Ppsh")]
    [SerializeField] private int _numberOfBullet;
    [SerializeField] private Text _bulletText;
    [SerializeField] private PlayerArmory _playerArmory;
    
    private void Start()
    {
        UpdateText();
    }
    
    public override void Shot()
    {
        base.Shot();
        _numberOfBullet -= 1;
        UpdateText();
        if (_numberOfBullet == 0)
        {
            _playerArmory.TakeGunByIndex(0); 
        }
    }

    public override void Activate()
    {
        base.Activate();
        _bulletText.enabled = true;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _bulletText.enabled = false;
    }

    private void UpdateText()
    {
        _bulletText.text = "Пули:" + _numberOfBullet.ToString();
    }

    public override void AddBullets(int bulletCount)
    {
        base.AddBullets(bulletCount);
        _numberOfBullet += bulletCount;
        UpdateText();
        _playerArmory.TakeGunByIndex(1);
    }
}
