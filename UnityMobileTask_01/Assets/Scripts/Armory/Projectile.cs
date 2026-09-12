using UnityEngine;
using Armory;

public class Projectile : MonoBehaviour
{
    private Bullet bulletData;
    private ObjectPool pool;
    private float lifeTimer;

    public void Initialize(Bullet data, ObjectPool objectPool)
    {
        bulletData = data;
        pool = objectPool;
        lifeTimer = 0f;
    }

    private void Update()
    {
        transform.position += transform.forward * (bulletData.speed * Time.deltaTime);

        lifeTimer += Time.deltaTime;

        if (lifeTimer >= bulletData.lifeTime)
        {
            pool.ReturnObject(gameObject);
        }
    }
}