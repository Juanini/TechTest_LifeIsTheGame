using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    [CreateAssetMenu(fileName = "GunData", menuName = "ScriptableObjects/GunData", order = 1)]
    public class GunData : ScriptableObject
    {
        [BoxGroup("Firearm Properties")]
        [Range(0.1f, 5f)]
        public float shootSpeed;

        [BoxGroup("Componentes")] 
        [PreviewField(150, ObjectFieldAlignment.Center)]
        public GameObject model;

        [BoxGroup("Firearm Properties")]
        [ValueDropdown("FirearmTypeOptions")]
        public int type = 0;
        
        [BoxGroup("Firearm Properties")] 
        public GameObject bullet;

        private static IEnumerable FirearmTypeOptions = new ValueDropdownList<int>()
        {
            { "Firearm Parabol",    GameConstants.GUN_PARABOL      },
            { "Firearm Black Hole", GameConstants.GUN_BLACKHOLE    },
            { "Firearm Extra",      GameConstants.GUN_EXTRA        },
        };
    }
}
