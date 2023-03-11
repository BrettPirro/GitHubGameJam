using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace GitHub.Puzzles
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class LockIntoPlace : MonoBehaviour
    {
        [SerializeField] int OBJID;

        bool MoveIntoPlaceBool = false;

        Transform Pos;

        public delegate void LockedIn();
        public event LockedIn PuzzleFinished;


        private void OnTriggerEnter2D(Collider2D collision)
        {

            
            try
            {
                if (collision.gameObject.GetComponent<DraggableObj>().ReturnId() == OBJID)
                {
                    Pos = collision.gameObject.transform;
                    collision.gameObject.layer = 2;
                    MoveIntoPlaceBool = true;
                    collision.GetComponent<DraggableObj>().ToggleDragging(true);
                  


                }
            }
            catch
            {
                Debug.Log("not a draggableOBJ");

            }
        }

      


        
      

       
        void Update()
        {

            if (MoveIntoPlaceBool) 
            {
                var UpdatedPos = Vector2.Lerp(Pos.position, transform.position, 0.8f);
                Pos.position=UpdatedPos;
                if (CheckIfAllAreInPlace()) { PuzzleFinished(); }

            }


        }

      


        public bool CheckIfAllAreInPlace()
        {
            

            int Total = 0;
            int InPlace = 0;

            foreach (DraggableObj obj in FindObjectsOfType<DraggableObj>())
            {
                Total++;
                if (obj.ReturnDragTog()) { InPlace++; }



            }

            return Total == InPlace;
        }


    }

  


}

