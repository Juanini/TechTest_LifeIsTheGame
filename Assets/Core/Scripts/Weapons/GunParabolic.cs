using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class GunParabolic : Gun
    {
        public float yModifier = 0.7f;
        public float throwForce = 5f;

        void Start()
        {
            
        }

        public override void Fire()
        {
            ThrowBullet();
        }

        private void ThrowBullet()
        {
            GameObject bullet = GetBullet();
            bullet.transform.position = shoopPoint.transform.position;
            bullet.gameObject.SetActive(true);

            Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
            
            rigidbody.velocity = Vector3.zero;
        
            Trace.Log("FORWARD: " + shoopPoint.transform.forward);

            rigidbody.AddForce(new Vector3( shoopPoint.transform.forward.x, 
                                            shoopPoint.transform.forward.y + yModifier, 
                                            shoopPoint.transform.forward.z) * throwForce, ForceMode.Impulse); // Working

            DoRecoilAnim();
        }
    }
}
