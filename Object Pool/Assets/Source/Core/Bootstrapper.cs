using ObjectPoolSystem;
using PlayerSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private Shoot shoot;

        private BulletObjectPool bulletObjectPool;

        private void Awake()
        {
            bulletObjectPool = new BulletObjectPool(bulletPrefab);
            shoot.Init(bulletObjectPool);
            playerInput.Init(shoot);
        }
    }
}