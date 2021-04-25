using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    [CreateAssetMenu(fileName = "FirearmData", menuName = "ScriptableObjects/FirearmData", order = 1)]
    public class FirearmData : ScriptableObject
    {
        [BoxGroup("Componentes")] 
        [PreviewField(150, ObjectFieldAlignment.Center)]
        public GameObject model;

        [BoxGroup("Firearm Properties")]
        [ValueDropdown("FirearmTypeOptions")]
        public int type = 0;

        [BoxGroup("Firearm Properties")]
        [Range(1, 100)] 
        public int bulletAmount;
        
        [BoxGroup("Firearm Properties")] 
        public GameObject bullet;

        private static IEnumerable FirearmTypeOptions = new ValueDropdownList<int>()
        {
            { "Firearm Parabol",    GameConstants.FIREARM_PARABOL      },
            { "Firearm Black Hole", GameConstants.FIREARM_BLACKHOLE    },
            { "Firearm Extra",      GameConstants.FIREARM_EXTRA        },
        };
    }
}
