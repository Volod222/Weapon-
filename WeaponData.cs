using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Weapon", fileName = "Weapon")]
public class WeaponData : ScriptableObject
{
    [SerializeField] private WeaponType _type;
    [SerializeField] private float _speedShot;
    [SerializeField] private float _speedReload;
    [SerializeField] private float _timeNextShot;
    [SerializeField] private bool _activeRecharge;
    [SerializeField] private int _magazineCartridge;
    [SerializeField] private int _maxCartridge;

    public WeaponType Type => _type;
    public float SpeedShot => _speedShot;
    public float SpeedReload => _speedReload;
    public float TimeNextShot => _timeNextShot;
    public bool ActiveRecharge => _activeRecharge;
    public int MagazineCartridge => _magazineCartridge;
    public int MaxCartridge => _maxCartridge;
}