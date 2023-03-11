using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GitHub.VisualDisplay 
{
    [CreateAssetMenu(menuName = "Comic Attribute", fileName = "Comic")]
    public class ComicLeadOBJ : ScriptableObject
    {
        [SerializeField] Sprite Comic;

        [SerializeField] ComicLeadOBJ Next;

        [SerializeField] float DisplayTime;

        [SerializeField] float FadeTime=0.7f;

        [SerializeField] bool LoopToMainMenuOnFinish = false;

        public ComicLeadOBJ GrabNextPannel() 
        {
            return Next;
        }

        public Sprite GrabSprite() 
        {
            return Comic;
        }

        public float DisplayTimeIs() 
        {
            return DisplayTime;
        }

        public float FadeTimeIs()
        {
            return FadeTime;
        }

        public bool Loopis()
        {
            return LoopToMainMenuOnFinish ;
        }

    }

}