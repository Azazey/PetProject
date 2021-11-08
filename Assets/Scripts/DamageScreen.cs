using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    [SerializeField] private Image _damageScreen;

    public void StartEffect()
    {
        StartCoroutine(ShowDamageScreen());
    }

    private IEnumerator ShowDamageScreen()
    {
        _damageScreen.enabled = true;
        for (float t = 1; t > 0f; t-=Time.deltaTime * 2f)
        {
            _damageScreen.color = new Color(1,0,0,t);
            yield return null;
        }

        _damageScreen.enabled = false;
    }
}
