using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class VFXManager : MonoBehaviour
    {
        public static VFXManager Ins;
        
        public Pool explosionPool;

        void Awake()
        {
            if (Ins != null && Ins != this)
            {
                Destroy(this.gameObject);
            } 
            else 
            {
                Ins = this;
            }

            explosionPool.InitPool();
        }

        // * =====================================================================================================================================
        // * 

        public void ShowExplosion(Vector3 _pos)
        {
            GameObject explosionObj = explosionPool.GetPooledObject();
            explosionObj.transform.position = _pos;
            explosionObj.gameObject.SetActive(true);
        }
    }
}
