using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class BulletBlackHole : MonoBehaviour
    {
        public float VortexStrength = 1000f;
        private  List<Rigidbody> rigidBodyList;

        public float SwirlStrength = 5f;

        void Start () 
        {
            Setup();
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

        [Button(ButtonSizes.Large), GUIColor(0.4f, 0.8f, 1)]
        public void InitAchis()
        {
            foreach(Rigidbody g in rigidBodyList)
            {
                //to get them nice and swirly, use the perpendicular to the direction to the vortex
                Vector3 direction = transform.position - g.transform.position;
                var tangent = Vector3.Cross(direction, Vector3.up).normalized * SwirlStrength;
                g.velocity = tangent;
            }

            initDone = true;
        }

        public bool initDone = false;
        void Update()
        {
            // if(!initDone) { return; }

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
