using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class GunBlackHole : Gun
    {
        public float BulletForce = 10;

        public override void Fire()
        {
            if(!canShoot) { return; }
            CheckFire();

            ThrowBullet();   
        }

        private void ThrowBullet()
        {
            GameObject bullet = GetBullet();
            bullet.transform.position = shoopPoint.transform.position;
            bullet.gameObject.SetActive(true);

            Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
            
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(shoopPoint.transform.forward * BulletForce, ForceMode.Impulse);

            DoRecoilAnim();
        }
    }
}
