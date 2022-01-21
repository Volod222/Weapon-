using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class WeaponAnimation : MonoBehaviour
{
    private const string Shot = nameof(Shot);
    private const string Reset = nameof(Reset);
    private const string Reload = nameof(Reload);
    private const string ReloadStart = nameof(ReloadStart);
    private const string ReloadAmmo = nameof(ReloadAmmo);
    private const string ReloadEnd = nameof(ReloadEnd);
    private const string Idle = nameof(Idle);

    private Animation _animation;

    private void Awake()
    {
        _animation = GetComponent<Animation>();
    }

    public void PlayShot(float speed)
    {
        Play(Shot, speed);
    }

    public void PlayReload(float speed)
    {
        Play(Reload, speed);
    }

    public void ResetAnimation()
    {
        _animation.Play(Reset, PlayMode.StopSameLayer);
    }

    private void Play(string name, float speed)
    {
        _animation[Shot].speed = speed;
        _animation[Shot].time = 0;
        _animation.Play(name, PlayMode.StopSameLayer);
    }
}
