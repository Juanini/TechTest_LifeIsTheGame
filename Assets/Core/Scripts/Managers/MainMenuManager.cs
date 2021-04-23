using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class MainMenuManager : MonoBehaviour
    {
        public static MainMenuManager Ins;

        void Awake()
        {
            Ins = this;
        }

        
    }
}
