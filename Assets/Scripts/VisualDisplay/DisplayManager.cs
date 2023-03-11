using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GitHub.SceneManage;

namespace GitHub.VisualDisplay 
{
    public class DisplayManager : MonoBehaviour
    {

        [SerializeField] ComicLeadOBJ Starting=null;
        ComicLeadOBJ Current;
        Image BackDrop;


        private void Start()
        {
            Current = Starting;
            BackDrop = GetComponent<Image>();
            BackDrop.sprite = Starting.GrabSprite();
            StartCoroutine(LoadingThroughPannels());
        }

       

        IEnumerator LoadingThroughPannels() 
        {
            Fader fader = FindObjectOfType<Fader>();

            while (true)
            {

            
                yield return new WaitForSeconds(Current.DisplayTimeIs());
                if (Current.GrabNextPannel() == null && !Current.Loopis()) { FindObjectOfType<Scene_Manager>().LoadTheeNextLevel(Current.FadeTimeIs()); break; }
                else if(Current.GrabNextPannel() == null) { FindObjectOfType<Scene_Manager>().LoadTheeMainMenu(Current.FadeTimeIs()); break; }
                yield return fader.FadeIn(Current.FadeTimeIs());
                Current = Current.GrabNextPannel();
                BackDrop.sprite = Current.GrabSprite();
                yield return fader.FadeOut(Current.FadeTimeIs());
             

            }
        }





    }
}
