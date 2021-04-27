using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class DataManager : MonoBehaviour
    {
        public static DataManager Ins;

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

        public void SaveInt(string _key, int _value)
        {
            PlayerPrefs.SetInt(_key, _value);
        }

        public int LoadInt(string _key)
        {
            if(PlayerPrefs.HasKey(_key))
            {
                return PlayerPrefs.GetInt(_key);
            }

            return 0;
        }
    }
}

public class DataConstants 
{
    public static string DATA_DANCE_SELECTED = "DATA_DANCE_SELECTED";
}
