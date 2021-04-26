using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class BulletExplosion : Bullet
    {
        public float radius = 5;
        public float explosionForce = 700;

        private void OnCollisionEnter(Collision other) 
        {
            Expolode();
        }

        private void Expolode()
        {
            // Show Effect
            VFXManager.Ins.ShowExplosion(transform.position);

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
