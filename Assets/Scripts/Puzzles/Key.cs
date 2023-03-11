using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace GitHub.Puzzles 
{
    public class Key : MonoBehaviour
    {
       
        [SerializeField] int Index;
        [SerializeField] private UnityEvent Grabbed;



        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

                try 
                {
                    if (hit.collider.tag == "Key")
                    {

                        Grabbed.Invoke();
                        Destroy(gameObject);

                    }
                }
                catch 
                {
                    Debug.Log("Not Clicking On Readable OBJ");
                }
              
            }
        }
    
        public int GrabIndex() 
        {
            return Index;
        }

        public static bool FindKeyWithIndex(int look) 
        {
            foreach(Key key in FindObjectsOfType<Key>()) 
            {
                if (look == key.GrabIndex()) { return true; }
            }
            return false;
        }
        
    
    
    }

}