using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class BlackHoleCollider : MonoBehaviour
    {
        public BulletBlackHole bulletBlackHole;

        private void OnTriggerEnter(Collider other) 
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

            if(rb != null)
            {
                bulletBlackHole.AddObjetToBlackHole(rb);
            }    
        }
    }
}
