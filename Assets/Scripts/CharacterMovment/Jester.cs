using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GitHub.Puzzles;
using GitHub.AudioSystems;

namespace GitHub.CharacterMovment 
{
    [RequireComponent(typeof(Movment))]
    public class Jester : MonoBehaviour
    {
        Movment moving;
        [SerializeField] float speed = 2f;
        [SerializeField] float Distance = 6f;
        [SerializeField] Animator animator;
        [SerializeField] AudioClip Laugh;

        void Start()
        {
           
            moving = GetComponent<Movment>();
            AudioManager.PlayClipAt(Laugh, Camera.main.transform.position, 1, 1);
           

        }

        private void FixedUpdate()
        {
            moving.MoveAwayFromMouseX(speed,Distance);

        }

       
        public void KeyTakenFromJester() 
        {
          
            animator.SetBool("KeyTaken", true);



        }


    }
}
