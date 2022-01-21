using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private WeaponType _type;
    [SerializeField] private List<WeaponComponent> _weapons;

    public WeaponType Type => _type;
    public WeaponComponent Weapon => _weapons[0];

    public void Enable()
    {
        Weapon.Enable();
    }

    public void Disable()
    {
        Weapon.Disable();
    }
}
