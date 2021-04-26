using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class GunZeroG : Gun
    {
        public float VortexStrength = 1000f;
        List<GameObject> RigidBodies;

        public float SwirlStrength = 5f;

        void Start () 
        {
            foreach(GameObject g in RigidBodies){
                //to get them nice and swirly, use the perpendicular to the direction to the vortex
                Vector3 direction = transform.position - g.transform.position;
                var tangent = Vector3.Cross(direction, Vector3.up).normalized * SwirlStrength;
                g.GetComponent<Rigidbody>().velocity = tangent;
            }
        }

        void Update()
        {
            //apply the vortex force
            foreach(GameObject g in RigidBodies)
            {
                //force them toward the center
                Vector3 direction = transform.position - g.transform.position;
                g.GetComponent<Rigidbody>().AddForce(direction.normalized * Time.deltaTime * VortexStrength);
            }
        }
    }
}
