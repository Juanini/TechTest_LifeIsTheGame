using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsTheGame
{
    public class Bullet : MonoBehaviour
    {
        public float disableTime = 4;

        private void OnEnable() 
        {
            StartCoroutine(DisableBulletDelay());
        }

        private void OnDisable() 
        {
            CancelDisable();
        }

        public void CancelDisable()
        {
            StopCoroutine(DisableBulletDelay());
        }

        private IEnumerator DisableBulletDelay()
        {
            yield return new WaitForSeconds(disableTime);
            gameObject.SetActive(false);
        }
    }
}
