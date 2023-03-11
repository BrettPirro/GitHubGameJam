using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GitHub.VisualDisplay 
{
    public class Pannel : MonoBehaviour
    {
   
        [SerializeField] UnityEvent StandingOnPlat;
        [SerializeField] UnityEvent NotOnPlat;

       

        private void OnTriggerStay2D(Collider2D collision)
        {
            
            if (collision.tag == "Player") 
            {
                StandingOnPlat.Invoke();
            }
         
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                NotOnPlat.Invoke();
            }
        }


      


    }


}
