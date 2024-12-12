using ObjectPoolSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PlayerSystem
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private Transform shootPoint;
        private ObjectPool<Bullet> bulletPool;

        public void Init(ObjectPool<Bullet> pool)
        {
            bulletPool = pool;
        }

        public void ShootBullet()
        {
            Bullet bullet = bulletPool.TryGetFromPool();
            if (bullet != null)
            {
                bullet.transform.position = shootPoint.position;
                bullet.ActivateBullet();
            }
        }
    }
}
