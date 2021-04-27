using Sirenix.OdinInspector;
using GameEventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Ins;

        [BoxGroup("Components")] public GameObject pickUpImage;

        [BoxGroup("Gun Info")] public GameObject gunInfoPanel;
        [BoxGroup("Gun Info")] public GameObject gunInfoParabol;
        [BoxGroup("Gun Info")] public GameObject gunInfoBlackHole;
        [BoxGroup("Gun Info")] public GameObject gunInfoZeroG;

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

            SetupEvents();
        }

        private void Start() 
        {
            Hashtable ht = new Hashtable();
            ht.Add(GameEventParam.DANCE_TYPE, SaveDataManager.Ins.LoadInt(DataConstants.DATA_DANCE_SELECTED));
            GameEventManager.TriggerEvent(GameEvents.E_DANCE_SELECTED, ht);    
        }

        void Update()
        {
        
        }

        void OnDestroy() 
        {
            DestroyEvents();
        }

        // * =====================================================================================================================================
        // * 

        public void ShowWeaponPickUp(Hashtable _ht)
        {
            int wtype = (int)_ht[GameEventParam.E_WEAPON_PICKED_TYPE];
            
            gunInfoPanel.gameObject.SetActive(true);

            gunInfoParabol.gameObject.SetActive(false);
            gunInfoBlackHole.gameObject.SetActive(false);
            gunInfoZeroG.gameObject.SetActive(false);


            switch(wtype)
            {
                case GameConstants.GUN_PARABOL:
                gunInfoParabol.gameObject.SetActive(true);
                break;

                case GameConstants.GUN_BLACKHOLE:
                gunInfoBlackHole.gameObject.SetActive(true);
                break;

                case GameConstants.GUN_EXTRA:
                gunInfoZeroG.gameObject.SetActive(true);
                break;
            }

            pickUpImage.gameObject.SetActive(true);
        }

        public void HideWeaponPickUp(Hashtable _ht)
        {
            gunInfoPanel.gameObject.SetActive(false);
            pickUpImage.gameObject.SetActive(false);
        }

        // * =====================================================================================================================================
        // * EVENTS

        private void SetupEvents()
        {
            GameEventManager.StartListening(GameEvents.E_SHOW_WEAPON_PICK_UP, ShowWeaponPickUp);
            GameEventManager.StartListening(GameEvents.E_HIDE_WEAPON_PICK_UP, HideWeaponPickUp);
        }

        private void DestroyEvents()
        {
            GameEventManager.StopListening(GameEvents.E_SHOW_WEAPON_PICK_UP, ShowWeaponPickUp);
            GameEventManager.StopListening(GameEvents.E_HIDE_WEAPON_PICK_UP, HideWeaponPickUp);
        }
    }
}
