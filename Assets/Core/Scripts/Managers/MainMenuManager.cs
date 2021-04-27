using GameEventSystem;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace LifeIsTheGame
{
    public class MainMenuManager : MonoBehaviour
    {
        public static MainMenuManager Ins;

        [BoxGroup("Elements")] public Button selectButton;
        [BoxGroup("Elements")] public Button aboutButton;

        void Awake()
        {
            Application.targetFrameRate = 60;
            
            if (Ins != null && Ins != this)
            {
                Destroy(this.gameObject);
            } 
            else 
            {
                Ins = this;
            }

            SetupEvents();
            SetupButtons();
        }

        void OnDestroy() 
        {
            DestroyEvents();    
        }

        // * =====================================================================================================================================
        // * Setup

        private void SetupButtons()
        {
            selectButton.onClick.AddListener(OnSelectClick);
        }

        // * =====================================================================================================================================
        // * Dance Selection

        private void OnDanceSelected(Hashtable _ht)
        {
            
        }

        // * =====================================================================================================================================
        // * Select Flow

        private void OnSelectClick()
        {
            LoadingMenu.Ins.ShowLoading(OnLoadingShowComplete);
        }

        private void OnLoadingShowComplete()
        {
            SceneManager.LoadSceneAsync(GameConstants.SCENE_GAME);
        }

        // * =====================================================================================================================================
        // * Events

        private void SetupEvents()
        {
            GameEventManager.StartListening(GameEvents.E_DANCE_SELECTED, OnDanceSelected);
        }

        private void DestroyEvents()
        {
            GameEventManager.StopListening(GameEvents.E_DANCE_SELECTED, OnDanceSelected);
        }
    }
}
