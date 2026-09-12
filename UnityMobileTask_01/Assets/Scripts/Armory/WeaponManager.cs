using System.Collections.Generic;
using UnityEngine;

namespace Armory
{
    public class WeaponManager : MonoBehaviour
    {
        private Dictionary<Weapon, GameObject> weaponObjects = new();
        private Dictionary<GameObject, ObjectPool> poolsByPrefab = new();

        private Weapon activeWeapon;
        private GameObject activeWeaponObject;

        public void SwitchWeapon(Weapon weapon)
        {
            if (!weapon)
            {
                if (activeWeaponObject)
                {
                    activeWeaponObject.SetActive(false);
                }

                activeWeapon = null;
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

                activeWeaponObject.transform.localPosition =
                    new Vector3(0, 0, 1.2f);

                activeWeaponObject.transform.localRotation =
                    Quaternion.Euler(0, 180, 90);

                activeWeaponObject.transform.localScale =
                    Vector3.one * 3f;

                weaponObjects.Add(weapon, activeWeaponObject);
            }

            activeWeaponObject.SetActive(true);
        }

        public void Shoot()
        {
            if (!activeWeapon) return;

            Transform shootingPoint =
                activeWeaponObject.GetComponent<FirePoint>().firePoint;

            Bullet bulletData = activeWeapon.bullet;
            GameObject bulletPrefab = bulletData.prefab;

            ObjectPool pool = GetOrCreatePool(bulletPrefab);

            GameObject projectile = pool.GetObject();

            projectile.transform.SetPositionAndRotation(
                shootingPoint.position,
                shootingPoint.rotation
            );

            projectile.GetComponent<Projectile>()
                .Initialize(bulletData, pool);
        }

        private ObjectPool GetOrCreatePool(GameObject bulletPrefab)
        {
            if (!poolsByPrefab.TryGetValue(bulletPrefab, out ObjectPool pool))
            {
                GameObject poolObject =
                    new GameObject(bulletPrefab.name + " Pool");

                poolObject.transform.SetParent(transform);

                pool = poolObject.AddComponent<ObjectPool>();
                pool.Initialize(bulletPrefab);

                poolsByPrefab.Add(bulletPrefab, pool);
            }

            return pool;
        }
    }
}