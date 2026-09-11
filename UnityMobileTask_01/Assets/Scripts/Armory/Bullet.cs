using UnityEngine;

namespace Armory
{
    [CreateAssetMenu(fileName = "New Bullet", menuName = "Arsenal/Bullet")]
    public class Bullet: ScriptableObject
    {
        public GameObject prefab;
        public float lifeTime;
        public float speed;
        public float damage;
    }
}