using Sirenix.OdinInspector;
using GameEventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class Player : MonoBehaviour
    {
        [BoxGroup("Properties")] public float distanceToWeapon = 3.2f;

        [BoxGroup("Components")] public Transform head;
        [BoxGroup("Components")] public FpsController fpsController;

        private Firearm firearmeActive;

        void Start()
        {
        
        }

        void Update()
        {
            CheckWeaponDrop();

            if(Input.GetMouseButtonDown(0)) 
            {
				
            }
        }

        private void EquipWeapon()
        {
            
        }

        private void CheckPickUp()
        {
            if(Input.GetKey(KeyCode.E))
            {
                EquipWeapon();
            }
        }

        bool weaponLocated = false;

        // * =====================================================================================================================================
        // * Weapon Drops

        private void CheckWeaponDrop()
        {
            Ray ray = new Ray(head.position, head.forward);
            if( Physics.Raycast(ray, out RaycastHit hit ) && 
                hit.collider.gameObject.tag == GameConstants.TAG_WEAPON_DROP )
            {
                float distance = Vector3.Distance(hit.collider.gameObject.transform.position, transform.position);
                if(distance <= distanceToWeapon)
                {
                    OnWeaponLocated();
                }
                else
                {
                    OnWeaponNoLocate();
                }
            }
            else
            {
                OnWeaponNoLocate();
            }
        }

        private void OnWeaponNoLocate()
        {
            if(weaponLocated) { return; }
            
            Trace.Log("Weapon not located");
            GameEventManager.TriggerEvent(GameEvents.E_HIDE_WEAPON_PICK_UP);
            weaponLocated = true;
        }

        private void OnWeaponLocated()
        {
            if(!weaponLocated) { return; }
            
            Trace.Log("Weapon not located");
            GameEventManager.TriggerEvent(GameEvents.E_SHOW_WEAPON_PICK_UP);
            weaponLocated = false;
        }
    }
}
