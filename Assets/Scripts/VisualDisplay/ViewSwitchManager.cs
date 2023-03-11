using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GitHub.Puzzles;
using GitHub.CharacterMovment;

namespace GitHub.VisualDisplay 
{
    public class ViewSwitchManager : MonoBehaviour
    {
        Animator animator;

        [SerializeField] int KeyIndexRequired;
        [SerializeField] Button button;
        bool onPlat=true;
        string WhichVartoChangeinAnimator;
        [SerializeField]bool intialLoadDone=false;
            



        void Start()
        {
            animator = GetComponent<Animator>();
           

        }

       

        public void EnableBtnIntial()
        {
            if (button.interactable == true) { return; }
            button.interactable = (!Key.FindKeyWithIndex(KeyIndexRequired));
            intialLoadDone = true;
        }

        public void UpdateBool(bool Updatevar)
        {
            onPlat = Updatevar;
            if (!intialLoadDone) { return; }
            button.interactable = Updatevar;
        }

        public void UpdateStringvar(string Updatevar) 
        {
            WhichVartoChangeinAnimator = Updatevar;
        }

        public void SwitchView() 
        {
            if (onPlat)
            {
                animator.SetBool(WhichVartoChangeinAnimator, !animator.GetBool(WhichVartoChangeinAnimator));
            }
        }
        
    
    
    
    
    }

}
