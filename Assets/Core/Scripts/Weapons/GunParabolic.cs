using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class GunParabolic : Gun
    {
        [BoxGroup("Properties")] public float yModifier = 0.7f;
        [BoxGroup("Properties")] public float bulletForce = 5f;
        
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

            rigidbody.AddForce(new Vector3( shoopPoint.transform.forward.x, 
                                            shoopPoint.transform.forward.y + yModifier, 
                                            shoopPoint.transform.forward.z) * bulletForce, ForceMode.Impulse); // Working

            DoRecoilAnim();
        }
    }
}
