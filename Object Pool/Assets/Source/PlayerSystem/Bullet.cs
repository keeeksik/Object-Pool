using ObjectPoolSystem;
using UnityEngine;

namespace PlayerSystem
{
    public class Bullet : MonoBehaviour, IPoolabel<Bullet>
    {
        [SerializeField] private float speed;
        [SerializeField] private float lifetime;

        private ObjectPool<Bullet> bulletPool;

        public void Init(ObjectPool<Bullet> pool)
        {
            bulletPool = pool;
        }

        public void ActivateBullet()
        {
            gameObject.SetActive(true);
            Invoke("DeactivateBullet", lifetime);
        }
        public void DeactivateBullet()
        {
            gameObject.SetActive(false);
            bulletPool.PushToPool(this);
        }

        private void Update()
        {
            transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        }
    }
}