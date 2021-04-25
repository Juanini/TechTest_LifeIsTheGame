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
        [BoxGroup("Components")] public PlayerWeapons playerWeapons;

        private WeaponDrop weaponDropFound;

        void Start()
        {
            
        }

        void Update()
        {
            CheckWeaponDrop();
            CheckPickUp();

            if(Input.GetMouseButtonDown(0)) 
            {
				
            }
        }

        private void EquipWeapon()
        {
            Hashtable ht = new Hashtable();
            ht.Add(GameEventParam.E_WEAPON_PICKED_TYPE, weaponDropFound.firearmData.type);
            GameEventManager.TriggerEvent(GameEvents.E_WEAPON_PICKED, ht);

            playerWeapons.EquipWeapon(weaponDropFound.firearmData.type);
            weaponDropFound.HideDrop();
        }

        private void CheckPickUp()
        {
            if(Input.GetKey(KeyCode.E))
            {
                if(weaponDropFound != null)
                {
                    EquipWeapon();
                }
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
                    OnWeaponLocated(hit);
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
            
            weaponDropFound = null;
            
            Trace.Log("Weapon not located");
            GameEventManager.TriggerEvent(GameEvents.E_HIDE_WEAPON_PICK_UP);
            weaponLocated = true;
        }

        private void OnWeaponLocated(RaycastHit _hit)
        {
            if(!weaponLocated) { return; }

            weaponDropFound = _hit.collider.GetComponent<WeaponDrop>();
            Trace.Log("Weapon Located! Type: " + weaponDropFound.firearmData.type);

            GameEventManager.TriggerEvent(GameEvents.E_SHOW_WEAPON_PICK_UP);
            weaponLocated = false;
        }
    }
}
