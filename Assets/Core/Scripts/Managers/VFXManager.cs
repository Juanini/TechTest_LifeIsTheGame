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

        public GameObject ShowEffect(string Tag, Vector3 _pos)
        {
            GameObject effect = explosionPool.GetPooledObject(Tag);
            effect.transform.position = _pos;
            effect.gameObject.SetActive(true);

            return effect; 
        }
    }
}
