using UnityEngine;

namespace Armory
{
    public enum Type
    {
        Single,
        Auto,
        Shotgun,
    }
    
    [CreateAssetMenu(fileName = "New Weapon Type", menuName = "Arsenal/Weapon Type")]
    public class WeaponType : ScriptableObject
    {
        public Type Type;
    }
}