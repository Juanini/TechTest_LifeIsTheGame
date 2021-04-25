using GameEventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Ins;

        public GameObject pickUpImage;

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
            pickUpImage.gameObject.SetActive(true);
        }

        public void HideWeaponPickUp(Hashtable _ht)
        {
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
