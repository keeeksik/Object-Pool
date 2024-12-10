using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerInput : MonoBehaviour
    {
        private Shoot shoot;

        public void Init(Shoot shoot)
        {
            this.shoot = shoot;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                shoot.ShootBullet();
            }
        }
    }
}
