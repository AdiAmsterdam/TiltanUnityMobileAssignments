using UnityEngine;

namespace Armory
{
    [CreateAssetMenu(fileName = "New Bullet", menuName = "Arsenal/Bullet")]
    public class Bullet: ScriptableObject
    {
        public Sprite sprite;
        public float lifeTime;
        public float speed;
        public float damage;
    }
}