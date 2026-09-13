using Armory;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hand : MonoBehaviour
{
    private WeaponManager weaponManager;

    [SerializeField] private Weapon[] weapons;

    private void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
    }

    private void Update()
    {
        if (Mouse.current != null &&
            Mouse.current.leftButton.isPressed)
        {
            weaponManager.Shoot();
        }

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            EquipWeapon(0);
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            EquipWeapon(1);
        }

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            EquipWeapon(2);
        }

        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            EquipWeapon(3);
        }
    }

    private void EquipWeapon(int index)
    {
        if (weapons == null || index >= weapons.Length)
        {
            return;
        }

        weaponManager.SwitchWeapon(weapons[index]);
    }
}