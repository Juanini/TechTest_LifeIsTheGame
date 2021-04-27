using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class Gun : MonoBehaviour
    {
        [BoxGroup("Data")] public GunData gunData;

        [BoxGroup("Components")] public Pool bulletPool;
        [BoxGroup("Components")] public GameObject shoopPoint;
        [BoxGroup("Components")] public GameObject gunModel;

        [BoxGroup("Properties")] public Vector3 positionInPlayer;
        [BoxGroup("Properties")] public Vector3 rotationInPlayer;

        [BoxGroup("Animations")] public float recoilDistance = 0.05f;
        [BoxGroup("Animations")] public float recoilTime = 0.1f;
        
        [HideInInspector] public bool canShoot = false;

        bool setupDone = false;
        
        void Start() { }

        void OnEnable() 
        {   
            if(setupDone) { return; }

            setupDone = true;
            
            SetPosition();
            CreateBulletPool();
        }

        public void SetPosition()
        {
            transform.localPosition = positionInPlayer;
            transform.localEulerAngles = rotationInPlayer;
        }

        public virtual void Fire() { }

        public void CheckFire()
        {
            canShoot = false;
            StartCoroutine(ShootSpeedDelay());
        }

        private IEnumerator ShootSpeedDelay()
        {
            yield return new WaitForSeconds(gunData.shootSpeed);
            canShoot = true;
        }

        // * =====================================================================================================================================
        // * 

        public void DoRecoilAnim()
        {
            Sequence mySequence = DOTween.Sequence();
            mySequence.Append(gunModel.transform.DOLocalMoveZ(recoilDistance, recoilTime));
            mySequence.Append(gunModel.transform.DOLocalMoveZ(0, recoilTime));

            mySequence.Play();
        }

        // * =====================================================================================================================================
        // * BULLETS

        private void CreateBulletPool()
        {
            bulletPool.itemsToPool = new List<ObjectPoolItem>();
            ObjectPoolItem objectPoolItem = new ObjectPoolItem();
            
            objectPoolItem.amountToPool = 10;
            objectPoolItem.objectToPool = gunData.bullet;
            objectPoolItem.shouldExpand = false;

            bulletPool.itemsToPool.Add(objectPoolItem);

            bulletPool.InitPool();
        }

        public GameObject GetBullet()
        {
            return bulletPool.GetPooledObject();
        }
    }
}
