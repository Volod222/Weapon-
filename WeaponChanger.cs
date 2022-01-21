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
        ViewWeapon(WeaponType.OneHandedColdArms);
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
                ViewWeapon(WeaponType.OneHandedColdArms);
                break;
            case 1:
                ViewWeapon(WeaponType.HandGun);
                break;
            case 2:
                ViewWeapon(WeaponType.MachineGun);
                break;
            case 3:
                ViewWeapon(WeaponType.GatlingGun);
                break;
            case 4:
                ViewWeapon(WeaponType.ShotGun);
                break;
            case 5:
                ViewWeapon(WeaponType.RocketLauncher);
                break;
            case 6:
                ViewWeapon(WeaponType.SniperRifle);
                break;
        }
    }

    private void ViewWeapon(WeaponType type)
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
