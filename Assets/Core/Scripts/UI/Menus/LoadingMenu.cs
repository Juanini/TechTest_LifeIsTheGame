using DG.Tweening;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LifeIsTheGame
{
    public class LoadingMenu : MonoBehaviour
    {
        public static LoadingMenu Ins;

        public Image panelImage;
        [Range(0.2f,0.5f)] public float fadeTime;
        [Range(1, 3)] public float loadingDelayTime;

        private UnityAction loadingCallback;

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

        public void ShowLoading(UnityAction _callback)
        {
            loadingCallback = _callback;
            panelImage.color = new Color(1, 1, 1, 0);
            panelImage.gameObject.SetActive(true);
            panelImage.DOFade(1, fadeTime).OnComplete(OnLoadingFadeInComplete);
        }

        private void OnLoadingFadeInComplete()
        {
            StartCoroutine(LoadingCompleteDelay());
        }

        private IEnumerator LoadingCompleteDelay()
        {
            yield return new WaitForSeconds(loadingDelayTime);
            loadingCallback?.Invoke();
        }
    }
}
