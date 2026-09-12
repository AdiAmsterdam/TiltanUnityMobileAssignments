using System.Collections.Generic;
using Armory;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hand : MonoBehaviour
{
    private WeaponManager weaponManager;
    [SerializeField] private Weapon[] weapons;
    void Awake()
    {
        weaponManager = gameObject.GetComponent<WeaponManager>();
    }
    
    void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            if (weapons != null) weaponManager.SwitchWeapon(weapons[0]);
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            if (weapons != null) weaponManager.SwitchWeapon(weapons[1]);
        }

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            if (weapons != null) weaponManager.SwitchWeapon(weapons[2]);
        }

        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            if (weapons != null) weaponManager.SwitchWeapon(weapons[3]);
        }
    }
}
