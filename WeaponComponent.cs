using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(WeaponAnimation))]
public class WeaponComponent : MonoBehaviour
{
    [SerializeField] private WeaponData _weapon;

    private WeaponAnimation _animation;
    private bool _isShot = false;

    private void Awake()
    {
        _animation = GetComponent<WeaponAnimation>();
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Shot()
    {
        if (_isShot == false)
            StartCoroutine(StartShot());
    }

    public void Reload()
    {
        if(_weapon.ActiveRecharge)
            _animation.PlayReload(_weapon.SpeedReload);
    }

    public void ResetAnimation()
    {
        _animation.ResetAnimation();
    }

    private IEnumerator StartShot()
    {
        _isShot = true;
        _animation.PlayShot(_weapon.SpeedShot);
        yield return new WaitForSeconds(_weapon.TimeNextShot);
        _isShot = false;
    }
}
