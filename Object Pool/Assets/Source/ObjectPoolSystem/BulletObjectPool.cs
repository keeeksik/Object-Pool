using PlayerSystem;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPoolSystem
{
    public class BulletObjectPool
    {
        private List<Bullet> bullets = new List<Bullet>();
        private int startPoolSize = 5;
        private int maxPoolSize = 15;
        private List<Bullet> usedBullets = new List<Bullet>();
        private Bullet bulletPrefab;

        public BulletObjectPool(Bullet prefab)
        {
            bulletPrefab = prefab;

            for (int i = 0; i < startPoolSize; i++)
            {
                Bullet bullet = Object.Instantiate(bulletPrefab);
                bullet.Init(this);
                bullets.Add(bullet);
            }
        }

        public void PushToPool(Bullet bullet)
        {
            if (usedBullets.Contains(bullet))
            {
                usedBullets.Remove(bullet);
                bullets.Add(bullet);
            }
        }

        public Bullet TryGetFromPool()
        {
            if(bullets.Count > 0)
            {
                Bullet bullet = bullets[0];
                usedBullets.Add(bullet);
                bullets.Remove(bullet);
                return bullet;
            }
            else if(usedBullets.Count < maxPoolSize)
            {
                Bullet newBullet = Object.Instantiate(bulletPrefab);
                newBullet.Init(this);
                usedBullets.Add(newBullet);
                return newBullet;
            }

            return null;
        }
    }
}