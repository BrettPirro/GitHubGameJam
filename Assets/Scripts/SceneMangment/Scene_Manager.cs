using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GitHub.VisualDisplay;
using GitHub.AudioSystems;

namespace GitHub.SceneManage 
{
    public class Scene_Manager : MonoBehaviour
    {
        Fader fader;


       


        void Awake()
        {
            fader = FindObjectOfType<Fader>();

            foreach (Scene_Manager obj in FindObjectsOfType<Scene_Manager>())
            {
                if (obj != this) { Destroy(obj.gameObject); }


            }



        }
      



        public void LoadTheeNextLevel(float time) 
        {
            StartCoroutine(LoadNextScene(time));
         
        }

        public void LoadTheeGameOver(float time)
        {
            StartCoroutine(LoadGameOver(time));
        }
        public void LoadTheeMainMenu(float time)
        {
            StartCoroutine(LoadMainMenu(time));
        }




        IEnumerator LoadNextScene(float time) 
       {
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            
            yield return fader.FadeIn(time / 2);
            yield return audioManager.AudioFadeOut(time / 2);

            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

            yield return audioManager.AudioFadeIn(time / 2);
            yield return fader.FadeOut(time / 2);
       }

        IEnumerator LoadMainMenu(float time)
        {
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            yield return fader.FadeIn(time / 2);
            yield return audioManager.AudioFadeOut(time / 2);
            yield return SceneManager.LoadSceneAsync("MainMenu");
            yield return audioManager.AudioFadeIn(time / 2);
            yield return fader.FadeOut(time / 2);
        }

        IEnumerator LoadGameOver(float time)
        {
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            yield return fader.FadeIn(time / 2);
            yield return audioManager.AudioFadeOut(time / 2);
            yield return SceneManager.LoadSceneAsync("GameOver");
            yield return audioManager.AudioFadeIn(time / 2);
            yield return fader.FadeOut(time / 2);
        }


    }
}
