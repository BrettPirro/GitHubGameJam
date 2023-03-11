using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GitHub.CharacterMovment 
{
    [RequireComponent(typeof(Movment))]
    public class Player : MonoBehaviour
    {
        [SerializeField]bool MovmentToggle = true;
        Movment movmentScript;
        [SerializeField] float speed = 5f;
   
       


        void Start()
        {
            movmentScript = GetComponent<Movment>();
        }


        private void FixedUpdate()
        {
            if (MovmentToggle) { movmentScript.UpdateVelocity(0,0); return; }
            Vector2 UpdatedVel = new Vector2((Input.GetAxisRaw("Horizontal") * speed), Input.GetAxisRaw("Vertical") * speed);

            UpdatedVel = Vector2.ClampMagnitude(UpdatedVel, speed);
            
            movmentScript.UpdateVelocity(UpdatedVel.x,UpdatedVel.y);

        }

        public void DisableMovment()
        {
           
            MovmentToggle = !MovmentToggle;
        }


       


    }

}