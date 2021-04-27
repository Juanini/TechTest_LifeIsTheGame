using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class BulletZeroG : Bullet
    {
        private void OnTriggerEnter(Collider other) 
        {
            if(other.gameObject.tag == GameConstants.TAG_FLOOR) 
            { 
                gameObject.SetActive(false);
                return; 
            }

            Rigidbody collisionRigidBody = other.GetComponent<Rigidbody>(); 

            if(collisionRigidBody == null) { return; }

            GameObject effect = VFXManager.Ins.ShowEffect(GameConstants.TAG_VFX_GRAVITY_GLOW, other.transform.position);
            
            gameObject.SetActive(false);
            effect.transform.parent = other.transform;

            rigidbody.velocity = Vector3.zero;
            collisionRigidBody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            
            transform.parent = other.transform;

            collisionRigidBody.useGravity = false;
            collisionRigidBody.angularDrag = 0;
            collisionRigidBody.velocity = transform.up * 5;
        }
    }
}
