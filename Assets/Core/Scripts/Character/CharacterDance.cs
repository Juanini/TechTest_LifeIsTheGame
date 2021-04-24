using GameEventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class CharacterDance : MonoBehaviour
    {
        public Animator characterAnim;

        void Awake()
        {
            GameEventManager.StartListening(GameEvents.E_DANCE_SELECTED, OnDanceSelected);
        }

        private void OnDanceSelected(Hashtable _ht)
        {
            int danceType = GameConstants.DANCE_TYPE_UNKOWN;

            if(_ht.ContainsKey(GameEventParam.DANCE_TYPE))
            {
                danceType = (int)_ht[GameEventParam.DANCE_TYPE];
            }

            if(danceType == GameConstants.DANCE_TYPE_UNKOWN) { return; }

            switch (danceType)
            {
                case GameConstants.DANCE_TYPE_HOUSE:
                characterAnim.Play("House Dancing");
                break;

                case GameConstants.DANCE_TYPE_MACARENA:
                characterAnim.Play("Macarena Dance");
                break;

                case GameConstants.DANCE_TYPE_HIP_HOP:
                characterAnim.Play("Wave Hip Hop Dance");
                break;

                default:
                characterAnim.Play("House Dancing");
                break;
                
            }            
        }
    }
}
