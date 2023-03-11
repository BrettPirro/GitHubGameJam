using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GitHub.CharacterMovment 
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movment : MonoBehaviour
    {
        Rigidbody2D Myrigidbody2D;

        private void Start()
        {
            Myrigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void MoveAwayFromMouseX(float speed,float distance)
        {
            var direction=0;
            var MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            if(MousePos.x < transform.position.x) 
            {
                direction = 1;
            }
            else 
            {
                direction = -1;
            }

            if (Vector2.Distance(MousePos, transform.position)>=distance) { return; }

            Myrigidbody2D.velocity=new Vector2 (speed * direction,Myrigidbody2D.velocity.y );


        }

        public void UpdateVelocity(float x, float y)  
        {
            Vector2 UpdatedMovment = new Vector2(x, y);

            Myrigidbody2D.velocity = UpdatedMovment;

        }
     
        public float GrabXVelocity() 
        {
            return Myrigidbody2D.velocity.x;
        }

        public float GrabYVelocity()
        {
            return Myrigidbody2D.velocity.y;
        }

    }
}
