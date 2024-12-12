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

        private ObjectPool<Bullet> bulletObjectPool;

        private void Awake()
        {
            bulletObjectPool = new ObjectPool<Bullet>(bulletPrefab);
            shoot.Init(bulletObjectPool);
            playerInput.Init(shoot);
        }
    }
}