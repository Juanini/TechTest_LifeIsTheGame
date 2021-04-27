using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Ins;
        public Player player;

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
        }

        void Start()
        {
        
        }

        // * =====================================================================================================================================
        // * Game Flow


    }
}
