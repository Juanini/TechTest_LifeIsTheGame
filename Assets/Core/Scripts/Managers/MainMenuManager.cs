using DG.Tweening;
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
        [BoxGroup("Elements")] public List<DanceSelectButton> danceSelectButtonList;

        [BoxGroup("About")] public Button aboutButton;
        [BoxGroup("About")] public GameObject aboutMenu;
        [BoxGroup("About")] public Button aboutCloseButton;

        private int danceSelected = 0;

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
            Setup();
        }

        void OnDestroy() 
        {
            DestroyEvents();    
        }

        // * =====================================================================================================================================
        // * Setup

        private void Setup()
        {
            danceSelectButtonList[0].OnDanceSelect();
            selectButton.onClick.AddListener(OnSelectClick);
            
            aboutButton.onClick.AddListener(ShowAbout);
            aboutCloseButton.onClick.AddListener(CloseAbout);
        }

        // * =====================================================================================================================================
        // * Dance Selection

        private void OnDanceSelected(Hashtable _ht)
        {
            danceSelected = (int)_ht[GameEventParam.DANCE_TYPE];

            for (int i = 0; i < danceSelectButtonList.Count; i++)
            {
                danceSelectButtonList[i].SetSelected(false);
            }
        }

        // * =====================================================================================================================================
        // * Select Flow

        private void OnSelectClick()
        {
            SaveDataManager.Ins.SaveInt(DataConstants.DATA_DANCE_SELECTED, danceSelected);
            LoadingMenu.Ins.ShowLoading(OnLoadingShowComplete);
        }

        private void OnLoadingShowComplete()
        {
            DOTween.KillAll();
            SceneManager.LoadSceneAsync(GameConstants.SCENE_GAME);
        }

        // * =====================================================================================================================================
        // * About

        private void ShowAbout()
        {
            aboutMenu.gameObject.SetActive(true);
        }

        private void CloseAbout()
        {
            aboutMenu.gameObject.SetActive(false);
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
