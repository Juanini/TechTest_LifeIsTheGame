using GameEventSystem;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class DanceSelectButton : MonoBehaviour
    {   
        private Button button;

        [ValueDropdown("DanceTypeOptions")] public int danceType;

        void Awake() 
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnDanceSelect);
        }

        private void OnDanceSelect()
        {
            Trace.Log("Dance Selected - Type: " + danceType);
            
            Hashtable ht = new Hashtable();
            ht.Add(GameEventParam.DANCE_TYPE, danceType);
            GameEventManager.TriggerEvent(GameEvents.E_DANCE_SELECTED, ht);
        }
        
        private void SetSelected(bool _selected)
        {

        }

        private static IEnumerable DanceTypeOptions = new ValueDropdownList<int>()
        {
            { GameConstants.DANCE_NAME_HOUSE,    GameConstants.DANCE_TYPE_HOUSE     },
            { GameConstants.DANCE_NAME_MACARENA, GameConstants.DANCE_TYPE_MACARENA  },
            { GameConstants.DANCE_NAME_HIP_HOP,  GameConstants.DANCE_TYPE_HIP_HOP   },
        };
    }
}
