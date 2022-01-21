using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(WeaponChanger))]
public class ScrollInput : MonoBehaviour
{
    [SerializeField] private int _maxWeaponCount;
    [SerializeField] private ScrollEvent _onChanged;

    private int _currentIndex = 0;

    public event UnityAction<int> OnChanged
    {
        add => _onChanged.AddListener(value);
        remove => _onChanged.RemoveListener(value);
    }

    private void Update()
    {
        UpdateScroll();
        UpdateInput();
    }

    private void UpdateScroll()
    {
        float scroll = Input.GetAxis(Axis.MouseScrollWheel);

        if (scroll < 0)
        {
            _currentIndex = _maxWeaponCount > _currentIndex + 1 ? ++_currentIndex : 0;
            _onChanged?.Invoke(_currentIndex);
        }
        else if (scroll > 0)
        {
            _currentIndex = _currentIndex > 0 ? --_currentIndex : _maxWeaponCount - 1;
            _onChanged?.Invoke(_currentIndex);
        }
    }

    private void UpdateInput()
    {
        if(int.TryParse(Input.inputString, out int result))
        {
            if(result <= _maxWeaponCount && result > 0)
            {
                if (_currentIndex != result - 1)
                {
                    _currentIndex = result - 1;
                    _onChanged?.Invoke(_currentIndex);
                }
            }
        }
    }

    [Serializable] class ScrollEvent : UnityEvent<int> { }
}
