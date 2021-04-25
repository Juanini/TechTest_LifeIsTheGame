using GameEventSystem;
using Sirenix.OdinInspector;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace LifeIsTheGame
{
    public class WeaponDrop : MonoBehaviour
    {
        [BoxGroup("Components")] public GunData firearmData;
        [BoxGroup("Components")] public GameObject weponModelContainer;
        [BoxGroup("Components")] public ParticleSystem glowParticles;
        [BoxGroup("Components")] public BoxCollider boxCollider;

        [BoxGroup("Anim properties")] public float bounceAnimTime = 1.35f;
        [BoxGroup("Anim properties")] public float rotationAnimTime = 2f;

        private GameObject model;

        void Awake() 
        {
            SetupEvents();
        }

        void Start()
        {
            Setup();
        }

        void OnDestroy() 
        {
            DestroyEvents();    
        }

        private void Setup()
        {
            model = GameObject.Instantiate(firearmData.model, 
                                           weponModelContainer.transform.position, 
                                           weponModelContainer.transform.rotation, 
                                           weponModelContainer.transform);
            SetModelAnim();
        }

        public void HideDrop()
        {
            boxCollider.enabled = false;
            weponModelContainer.gameObject.SetActive(false);
            glowParticles.gameObject.SetActive(false);
        }

        public void ShowDrop()
        {   
            boxCollider.enabled = true;
            weponModelContainer.gameObject.SetActive(true);
            glowParticles.gameObject.SetActive(true);
        }

        private void OnWeapoPicked(Hashtable _ht)
        {
            if(_ht.ContainsKey(GameEventParam.E_WEAPON_PICKED_TYPE))
            {
                if(firearmData.type != (int)_ht[GameEventParam.E_WEAPON_PICKED_TYPE])
                {
                    ShowDrop();
                }
            }
        }

        // * =====================================================================================================================================
        // * Animations

        private void SetModelAnim()
        {
            weponModelContainer.transform.DOLocalMove(new Vector3(0, -0.35f, 0), bounceAnimTime)
                                         .SetLoops(-1, LoopType.Yoyo)
                                         .SetEase(Ease.InOutCubic);

            model.transform.DOLocalRotate(new Vector3(0, 360, 0), rotationAnimTime, RotateMode.FastBeyond360)
                           .SetLoops(-1)
                           .SetEase(Ease.Linear);;
        }

        // * =====================================================================================================================================
        // * Setup Events

        private void SetupEvents()
        {
            GameEventManager.StartListening(GameEvents.E_WEAPON_PICKED, OnWeapoPicked);
        }

        private void DestroyEvents()
        {
            GameEventManager.StopListening(GameEvents.E_WEAPON_PICKED, OnWeapoPicked);
        }
    }
}
