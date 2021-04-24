using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    [CreateAssetMenu(fileName = "FirearmData", menuName = "ScriptableObjects/FirearmData", order = 1)]
    public class FirearmData : ScriptableObject
    {
        [BoxGroup("Firearm Properties")]
        [Range(1, 100)] public int bulletAmount;
        [BoxGroup("Firearm Properties")] public GameObject bullet;
    }
}
