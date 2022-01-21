using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControl : MonoBehaviour
{
    [SerializeField] private WeaponChanger _weaponChanger;

    private WeaponComponent CurrentWeapon => _weaponChanger.CurrentWeapon;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (_weaponChanger.IsChangeWeapon == false)
            {
                CurrentWeapon.Shot();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_weaponChanger.IsChangeWeapon == false)
            {
                CurrentWeapon.Reload();
            }
        }
    }
}
