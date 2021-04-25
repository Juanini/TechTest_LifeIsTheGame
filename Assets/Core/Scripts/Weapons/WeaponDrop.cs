using Sirenix.OdinInspector;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class WeaponDrop : MonoBehaviour
    {
        [BoxGroup("Elements")] public FirearmData firearmData;
        [BoxGroup("Elements")] public GameObject weponModelContainer;

        [BoxGroup("Anim properties")] public float bounceAnimTime = 1.35f;
        [BoxGroup("Anim properties")] public float rotationAnimTime = 2f;

        private GameObject model;

        void Start()
        {
            Setup();
        }

        private void Setup()
        {
            model = GameObject.Instantiate(firearmData.model, 
                                           weponModelContainer.transform.position, 
                                           weponModelContainer.transform.rotation, 
                                           weponModelContainer.transform);
            SetModelAnim();
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
    }
}
