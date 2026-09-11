using System.Collections.Generic;
using UnityEngine;

namespace Armory
{
    public class WeaponManager: MonoBehaviour
    {
        private Dictionary<Weapon, GameObject> weaponObjects = new();
        private Weapon activeWeapon;
        private GameObject activeWeaponObject;
        
        
        public void SwitchWeapon(Weapon weapon)
        {
            if (!weapon)
            {
                activeWeaponObject.SetActive(false);
                return;
            }
            
            if (activeWeaponObject)
            {
                activeWeaponObject.SetActive(false);
            }

            activeWeapon = weapon;
        
            if (!weaponObjects.TryGetValue(weapon, out activeWeaponObject))
            {
                activeWeaponObject = Instantiate(weapon.model, transform);

                activeWeaponObject.transform.localPosition = new Vector3(0, 0, 1.2f);
                activeWeaponObject.transform.localRotation = Quaternion.Euler(0, 180, 90);
                activeWeaponObject.transform.localScale = Vector3.one * 3f;
            
                weaponObjects.Add(weapon, activeWeaponObject);
            }
        
            activeWeaponObject.SetActive(true);
        }

        public void Shoot()
        {
            if (!activeWeapon) return;

            Transform shootingPoint = activeWeaponObject.GetComponent<FirePoint>().firePoint;
            Instantiate(activeWeapon.bullet.prefab, shootingPoint);
        }
    }
}