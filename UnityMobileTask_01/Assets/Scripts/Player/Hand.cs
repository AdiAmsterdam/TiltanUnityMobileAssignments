using Armory;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hand : MonoBehaviour
{
    private Weapon activeWeapon;
    private GameObject activeWeaponObject;
    [SerializeField] private Weapon[] weapons;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            SwitchWeapon(weapons[0]);
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            SwitchWeapon(weapons[1]);
        }

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            SwitchWeapon(weapons[2]);
        }

        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            SwitchWeapon(weapons[3]);
        }
    }

    public void SwitchWeapon(Weapon weapon)
    {
        activeWeapon = weapon;

        activeWeaponObject = Instantiate(activeWeapon.model, transform);

        activeWeaponObject.transform.localPosition = Vector3.zero;
        activeWeaponObject.transform.localRotation = Quaternion.identity;
        activeWeaponObject.transform.localScale = Vector3.one;
    }
}
