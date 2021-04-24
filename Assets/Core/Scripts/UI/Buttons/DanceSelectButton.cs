using TMPro;
using GameEventSystem;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;

namespace LifeIsTheGame
{
    public class DanceSelectButton : MonoBehaviour
    {   
        private Button button;
        private Image buttonImage;
        public TextMeshProUGUI buttonText;
        public Rectangle rectShapes;

        [ValueDropdown("DanceTypeOptions")] public int danceType;

        void Awake() 
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnDanceSelect);

            SetupButton();
        }

        private void SetupButton()
        {
            switch(danceType)
            {
                case GameConstants.DANCE_TYPE_HOUSE:
                buttonText.text = "House Dance";
                break;

                case GameConstants.DANCE_TYPE_MACARENA:
                buttonText.text = "Macarena!";
                break;

                case GameConstants.DANCE_TYPE_HIP_HOP:
                buttonText.text = "Hip Hop";
                break;

            }
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
            if(_selected)
            {
                rectShapes.gameObject.SetActive(true);
            }
            else
            {
                rectShapes.gameObject.SetActive(false);
            }
        }

        private void PlaySelectAnim()
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
