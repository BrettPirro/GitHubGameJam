using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GitHub.SceneManage;

namespace GitHub.Puzzles 
{

    [RequireComponent(typeof(Animator))]
    public class Doors : MonoBehaviour
    {
        [SerializeField] Lever LeverToCorrelateWithDoor;
        Animator animator;
        bool Opened = false;
        public delegate void DoorOpened();
        public event DoorOpened DoorOpening;



        void Start()
        {
            animator = GetComponent<Animator>();
        }

      

        public void DoorCondtion()
        {
            if (animator.GetFloat("OpenVar") == 1 && !Opened)
            {
                DoorOpening();
                Opened = true;
            }
        }

      

        void Update()
        {
            animator.SetFloat("OpenVar", LeverToCorrelateWithDoor.ReturnProggress());
        }
    }

}