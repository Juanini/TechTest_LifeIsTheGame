using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class PlayerWeapons : MonoBehaviour
    {
        [BoxGroup("Components")] public Player player;

        [BoxGroup("Prefab Ref")] public Gun gunParabolPrefab;
        [BoxGroup("Prefab Ref")] public Gun gunBlackHolePrefab;
        [BoxGroup("Prefab Ref")] public Gun gunExtraPrefab;

        private Gun weaponActive;

        private Gun gunParabol   = null;
        private Gun gunBlackHole = null;
        private Gun gunExtra     = null;

        public void FIre()
        {
            if(weaponActive == null) { return; }

            weaponActive.Fire();
        }

        public void EquipWeapon(int _gunType)
        {
            switch(_gunType)
            {
                case GameConstants.GUN_PARABOL:
                CheckWeaponSpawn(ref gunParabol, gunParabolPrefab);
                break;

                case GameConstants.GUN_BLACKHOLE:
                CheckWeaponSpawn(ref gunBlackHole, gunBlackHolePrefab);
                break;

                case GameConstants.GUN_EXTRA:
                CheckWeaponSpawn(ref gunExtra, gunExtraPrefab);
                break;

                default:
                CheckWeaponSpawn(ref gunParabol, gunParabolPrefab);
                break;
            }
        }

        private void CheckWeaponSpawn(ref Gun _gun, Gun _gunPrefab)
        {
            Trace.Log(this.name + " - " + "CheckWeaponSpawn");

            if(_gun == null)
            {
                Trace.Log(this.name + " - " + "Creating Weapon");
                _gun = GameObject.Instantiate(  _gunPrefab,
                                                player.head.transform.position, 
                                                player.head.transform.rotation, 
                                                player.head.transform);
            }
            
            gunParabol?.gameObject.SetActive(false);
            gunBlackHole?.gameObject.SetActive(false);
            gunExtra?.gameObject.SetActive(false);

            weaponActive = _gun;
            weaponActive.shoopPoint.transform.LookAt(GameManager.Ins.player.shootDir.transform);
            weaponActive.gameObject.SetActive(true);
        }
    }
}
