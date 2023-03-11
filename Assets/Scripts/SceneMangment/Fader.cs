using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace GitHub.SceneManage 
{
    [RequireComponent(typeof(CanvasGroup))]

    public class Fader : MonoBehaviour
    {
        CanvasGroup canvas;
     



        private void Awake()
        {
           canvas = GetComponent<CanvasGroup>();
        }

      

        public IEnumerator FadeIn(float Timer) 
        {
        
            while (canvas.alpha<1) 
            {
                canvas.alpha += Time.deltaTime / Timer;
                yield return null;
            }

        }


        public IEnumerator FadeOut(float Timer)
        {
            while (canvas.alpha > 0)
            {
                canvas.alpha -= Time.deltaTime / Timer;
                yield return null;
            }

        }

        public void FadeInFunc(float Timer) 
        {
     
            StartCoroutine(FadeIn(Timer));
        }

        public void FadeOutFunc(float Timer)
        {

            StartCoroutine(FadeOut(Timer));
        }

        public void InstantFadeOut() 
        {
            canvas.alpha = 0;
        }

        public void InstantFadeIn()
        {
            canvas.alpha = 1;
        }


    }
}
