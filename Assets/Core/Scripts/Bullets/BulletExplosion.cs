using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class BulletExplosion : Bullet
    {
        [BoxGroup("Properties")] public float radius = 5;
        [BoxGroup("Properties")] public float explosionForce = 700;

        private void OnCollisionEnter(Collision other) 
        {
            Expolode();
        }

        private void Expolode()
        {
            // Show Effect
            VFXManager.Ins.ShowEffect(GameConstants.TAG_VFX_EXPLOSION, transform.position);

            // Get nearby objects
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach(Collider nearbyObj in colliders)
            {
                Rigidbody rb = nearbyObj.GetComponent<Rigidbody>();

                if(rb != null)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, radius);
                }
            }

            gameObject.SetActive(false);
        }
    }
}
