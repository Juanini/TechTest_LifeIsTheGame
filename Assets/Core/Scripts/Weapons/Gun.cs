using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class Gun : MonoBehaviour
    {
        public GunData firearmData;

        public Vector3 positionInPlayer;
        public Vector3 rotationInPlayer;
        
        void Start()
        {
        
        }

        void Update()
        {
        
        }

        public void Fire()
        {

        }

        void OnEnable() 
        {   
            transform.localPosition = positionInPlayer;
            transform.localEulerAngles = rotationInPlayer;
        }
    }
}
