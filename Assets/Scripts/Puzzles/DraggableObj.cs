using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GitHub.Puzzles 
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class DraggableObj : MonoBehaviour
    {

        [SerializeField] int objID;
        [SerializeField] [Range(0f,1f)]float MousetoPosSpeed = 2f;
        bool DisableDrag = false;
     

        private void Awake()
        {
            foreach (DraggableObj obj in FindObjectsOfType<DraggableObj>())
            {
                if (obj != this && obj.ReturnId() == this.ReturnId()) { Destroy(gameObject); }
            }
        }
        private void OnMouseDrag()
        {
            if (DisableDrag) { return; }

            var MousePos = Vector2.Lerp(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position, MousetoPosSpeed * Mathf.Pow(0.5f, Time.deltaTime));
            transform.position = MousePos;
            
        }

        public void ToggleDragging(bool Change) 
        {
            DisableDrag = Change;
        }

        public bool ReturnDragTog()
        {
            return DisableDrag;
        }


        public int ReturnId()
        {
            return objID;
        }

    }

}