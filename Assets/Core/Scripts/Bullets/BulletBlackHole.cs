using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class BulletBlackHole : Bullet
    {
        [BoxGroup("Properties")] public float VortexStrength = 1000f;
        [BoxGroup("Properties")] private  List<Rigidbody> rigidBodyList;

        public float SwirlStrength = 5f;

        void Start()
        {
            Setup();
        }

        private void OnDisable() 
        {
            rigidBodyList.Clear();
        }

        private void Setup()
        {
            rigidBodyList = new List<Rigidbody>();
        }

        public void AddObjetToBlackHole(Rigidbody _obj)
        {
            if(rigidBodyList.Contains(_obj)) { return; }

            Vector3 direction = transform.position - _obj.transform.position;
            var tangent = Vector3.Cross(direction, Vector3.up).normalized * SwirlStrength;
            _obj.GetComponent<Rigidbody>().velocity = tangent;

            rigidBodyList.Add(_obj);
        }

        void Update()
        {
            //apply the vortex force
            foreach(Rigidbody g in rigidBodyList)
            {
                //force them toward the center
                Vector3 direction = transform.position - g.transform.position;
                g.AddForce(direction.normalized * Time.deltaTime * VortexStrength);
            }
        }
        
    }
}
