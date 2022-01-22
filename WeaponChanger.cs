using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(ScrollAnimation))]
public class WeaponChanger : MonoBehaviour
{
    [SerializeField] private List<WeaponView> _weaponViews;
    [SerializeField] private float _delayChange;

    private ScrollAnimation _animation;

    public bool IsChangeWeapon => _animation.IsPlaying(_animation.WeaponChangeAnimation);
    public WeaponComponent CurrentWeapon { get; private set; }

    private void Awake()
    {
        _animation = GetComponent<ScrollAnimation>();
    }

    private void Start()
    {
        DisplayWeapon(WeaponType.OneHandedColdArms);
    }

    public void ChangeWeapon(int index)
    {
        StartCoroutine(Change(index));
    }

    private IEnumerator Change(int index)
    {
        _animation.Play(_animation.WeaponChangeAnimation);
        yield return new WaitForSeconds(_delayChange);

        switch (index)
        {
            case 0:
                DisplayWeapon(WeaponType.OneHandedColdArms);
                break;
            case 1:
                DisplayWeapon(WeaponType.HandGun);
                break;
            case 2:
                DisplayWeapon(WeaponType.MachineGun);
                break;
            case 3:
                DisplayWeapon(WeaponType.GatlingGun);
                break;
            case 4:
                DisplayWeapon(WeaponType.ShotGun);
                break;
            case 5:
                DisplayWeapon(WeaponType.RocketLauncher);
                break;
            case 6:
                DisplayWeapon(WeaponType.SniperRifle);
                break;
        }
    }

    private void DisplayWeapon(WeaponType type)
    {
        foreach (var weaponView in _weaponViews)
        {
            if (weaponView.Type == type)
            {
                CurrentWeapon = weaponView.Weapon;
                weaponView.Enable();
                continue;
            }

            weaponView.Disable();
        }

        CurrentWeapon.ResetAnimation();
    }
}
