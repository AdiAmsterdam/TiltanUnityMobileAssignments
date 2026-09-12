using UnityEngine;

namespace Armory
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Arsenal/Weapon")]
    public class Weapon: ScriptableObject
    {
        public string weaponName;
        public GameObject model;
        public Bullet bullet;
        public WeaponType weaponType;
        
        public int projectileCount;
        public float firerate;
    }
}